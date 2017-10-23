/*
 * Created by SharpDevelop.
 * User: YLIN68
 * Date: 12/10/2015
 * Time: 1:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client; // ODP.NET Oracle managed provider 
using Oracle.ManagedDataAccess.Types; 
using System.Threading.Tasks;

namespace opassword
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		DataTable dt;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		static DataTable GetDataSources()
		{
			OracleClientFactory factory=new OracleClientFactory();
			if (factory.CanCreateDataSourceEnumerator)
			{
				DbDataSourceEnumerator dsenum = factory.CreateDataSourceEnumerator();
				DataTable dt1 = dsenum.GetDataSources();
				dt1.Columns.Remove("Protocol");
				dt1.Columns.Remove("Port");
				dt1.Columns.Add("Selected",System.Type.GetType("System.Boolean")).SetOrdinal(0);
				dt1.Columns.Add("User",System.Type.GetType("System.String"));
				dt1.Columns.Add("Password",System.Type.GetType("System.String"));
				dt1.Columns.Add("New Password",System.Type.GetType("System.String"));
				dt1.Columns.Add("Result",System.Type.GetType("System.String"));
				dt1.Columns.Add("Expiry Date",System.Type.GetType("System.String"));
				foreach(DataRow row in dt1.Rows)
				{
					row["Selected"]=false;
					row["User"]=row["Password"]=row["New Password"]=row["Result"]=row["Expiry Date"]="";
				}
				return dt1;
			}
			else
			  return null;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			dataGridView1.DataSource=dt=GetDataSources();
			
			foreach(DataGridViewColumn col in dataGridView1.Columns)
			{
				if(col.Name!="Selected" && col.Name!="User" && col.Name!="Password" && col.Name!="New Password")
					col.ReadOnly=true;
				else
				{
					//col.AutoSizeMode=DataGridViewAutoSizeColumnMode.AllCells;
					dataGridView1.AutoResizeColumn(col.Index);
				}
			}
			dataGridView1.Columns["Selected"].SortMode= DataGridViewColumnSortMode.Automatic;
			dataGridView1.RowHeadersWidth=50;
		}
		void CbSelectAllClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				row["Selected"]=cbSelectAll.Checked;
			}
		}
		void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex<0) return;
			if(dataGridView1.Columns[e.ColumnIndex].Name=="Selected")
			{
				bool allSelected=true;
				bool noneSelected=true;
				foreach(DataRow row in dt.Rows)
				{
					allSelected=allSelected && (bool)row["Selected"];
					noneSelected=noneSelected && !(bool)row["Selected"];
					if(!allSelected && !noneSelected) break;
				}
				if(allSelected) cbSelectAll.CheckState=CheckState.Checked;
				else if(noneSelected) cbSelectAll.CheckState=CheckState.Unchecked;
				else cbSelectAll.CheckState=CheckState.Indeterminate;
			}
		}
		void DataGridView1CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if(dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name=="Selected")
			{
				dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}
		void BtCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		async void btCheckClick(object sender, EventArgs e)
		{
			btCheck.Enabled=btChange.Enabled=false;
			
			int currentRow=dataGridView1.CurrentCell.RowIndex;
			int currentCol=dataGridView1.CurrentCell.ColumnIndex;
			int firstCol=dataGridView1.FirstDisplayedScrollingColumnIndex;
			int firstRow=dataGridView1.FirstDisplayedScrollingRowIndex;
			
			dataGridView1.DataSource=dt=dt.DefaultView.ToTable();
			
			dataGridView1.CurrentCell=dataGridView1.Rows[currentRow].Cells[currentCol];
			dataGridView1.FirstDisplayedScrollingColumnIndex=firstCol;
			dataGridView1.FirstDisplayedScrollingRowIndex=firstRow;
			
			List<Task> tasks=new List<Task>();
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					while(tasks.Count>=nThreads.Value)
					{
						Task task=await Task.WhenAny(tasks);
						tasks.Remove(task);
					}
					tasks.Add(CheckAsync(row));
				}
			}
			await Task.WhenAll(tasks);
			btCheck.Enabled=btChange.Enabled=true;
		}
		async void btChangeClick(object sender, EventArgs e)
		{
			btCheck.Enabled=btChange.Enabled=false;

			int currentRow=dataGridView1.CurrentCell.RowIndex;
			int currentCol=dataGridView1.CurrentCell.ColumnIndex;
			int firstCol=dataGridView1.FirstDisplayedScrollingColumnIndex;
			int firstRow=dataGridView1.FirstDisplayedScrollingRowIndex;
			
			dataGridView1.DataSource=dt=dt.DefaultView.ToTable();

			dataGridView1.CurrentCell=dataGridView1.Rows[currentRow].Cells[currentCol];
			dataGridView1.FirstDisplayedScrollingColumnIndex=firstCol;
			dataGridView1.FirstDisplayedScrollingRowIndex=firstRow;
			
			List<Task> tasks=new List<Task>();
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					while(tasks.Count>=nThreads.Value)
					{
						Task task=await Task.WhenAny(tasks);
						tasks.Remove(task);
					}
					tasks.Add(ChangeAsync(row));
				}
			}
			await Task.WhenAll(tasks);
			btCheck.Enabled=btChange.Enabled=true;
		}	
		async Task CheckAsync(DataRow row)
		{
			string db=row["InstanceName"].ToString();
			string user=row["User"].ToString();
			string password=row["Password"].ToString();
			row["Result"]="Connecting...";
			string expiry="";
			string result=await Task<string>.Run(()=>{return Check(db,user,password,out expiry);});
			row["Result"]=result;
			row["Expiry Date"]=expiry;
		}
		string Check(string db,string user,string password,out string expiry)
		{
			string oradb = String.Format("Data Source={0};User Id={1};Password={2};Pooling=false",db,user,password);
			expiry="";
			
			//using(System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(oradb))
			using(OracleConnection conn = new OracleConnection(oradb))
			{
				try
				{
					conn.Open();
					//using(System.Data.OracleClient.OracleCommand cmd=conn.CreateCommand())
					using(OracleCommand cmd=conn.CreateCommand())
					{
						cmd.BindByName=true;
						cmd.CommandText="select to_char(expiry_date,'yyyy-mm-dd hh24:mi:ss') from user_users where username=upper(:username)";
						cmd.Parameters.Add("username",user);
						object r=cmd.ExecuteScalar()??"";
						expiry=r.ToString();
					}
					return "Success";
				}
				catch(Exception e)
				{
					return e.Message;
				}
			}						
		}

		async Task ChangeAsync(DataRow row)
		{
			string db=row["InstanceName"].ToString();
			string user=row["User"].ToString();
			string password=row["Password"].ToString();
			string newPassword=row["New Password"].ToString();
			row["Result"]="Connecting...";
			string expiry="";
			string result=await Task<string>.Run(()=>{return Change(db,user,password,newPassword,out expiry);});
			row["Result"]=result;
			row["Expiry Date"]=expiry;
		}
		string Change(string db,string user,string password,string newPassword,out string expiry)
		{
			string oradb = String.Format("Data Source={0};User Id={1};Password={2};Pooling=false",db,user,password);
			expiry="";
			//using(System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(oradb))
			using(OracleConnection conn = new OracleConnection(oradb))
			{
				try
				{
					try
					{
						conn.Open();
						using(OracleCommand cmd=conn.CreateCommand())
						{
							cmd.CommandText=String.Format("alter user {0} identified by \"{1}\" replace \"{2}\"",user,newPassword,password);
							cmd.ExecuteNonQuery();
						}
					}
					catch(OracleException ex)
					{
						if(ex.Number==28001) //Password expired
						{
							conn.OpenWithNewPassword(newPassword);
						}
						else
						{
							throw;
						}
					}
					using(OracleCommand cmd=conn.CreateCommand())
					{
						cmd.BindByName=true;
						cmd.CommandText="select to_char(expiry_date,'yyyy-mm-dd hh24:mi:ss') from user_users where username=upper(:username)";
						cmd.Parameters.Add("username",user);
						object r=cmd.ExecuteScalar()??"";
						expiry=r.ToString();
					}
					return "Success";
				}
				catch(Exception e)
				{
					return e.Message;
				}
			}						
		}
		void DataGridView1CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(dataGridView1.Columns[e.ColumnIndex].Name=="Result")
			{
				if(e.Value.ToString()=="Success")
					e.CellStyle.ForeColor=Color.Green;
				else if(e.Value.ToString().StartsWith("Connecting"))
					e.CellStyle.ForeColor=Color.Black;
				else
					e.CellStyle.ForeColor=Color.Red;
			}
			if( (dataGridView1.Columns[e.ColumnIndex].Name=="Password") || (dataGridView1.Columns[e.ColumnIndex].Name=="New Password") )
			{
				if(e.Value!=null && !cbShowPassword.Checked)
				{
					e.Value=new string('*',e.Value.ToString().Length);
				}
			}
				
		}
		void BtPasswordClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					row["Password"]=tbPassword.Text;
				}
			}
		}
		void BtNewPasswordClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					row["New Password"]=tbNewPassword.Text;
				}
			}
	
		}
		void BtUserClick(object sender, EventArgs e)
		{
			foreach(DataRow row in dt.Rows)
			{
				if((bool)row["Selected"])
				{
					row["User"]=tbUser.Text;
				}
			}
	
		}
		bool FindFirst(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
				if(i==dataGridView1.Rows.Count-1) i=0;
				else i++;
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		bool FindNext(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				if(i==dataGridView1.Rows.Count-1) i=0;
				else i++;
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		bool FindPrev(string key)
		{
			DataGridViewCell cell;
			DataGridViewRow row;
			int i=dataGridView1.CurrentRow.Index;
			do
			{
				if(i==0) i=dataGridView1.Rows.Count-1;
				else i--;
				row=dataGridView1.Rows[i];
				cell=Match(row,key);
				if(cell!=null)
				{
					dataGridView1.CurrentCell=cell;
					return true;
				}
			} while(i!=dataGridView1.CurrentRow.Index);
			return false;
		}
		DataGridViewCell Match(DataGridViewRow row,string key)
		{
			if(row.Cells["InstanceName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["InstanceName"];
			else if(row.Cells["ServerName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["ServerName"];
			else if(row.Cells["ServiceName"].Value.ToString().ToLower().Contains(key.ToLower()))
				return row.Cells["ServiceName"];
			else
				return null;
		}
		void TbFindTextChanged(object sender, EventArgs e)
		{
			FindFirst(tbFind.Text);
		}
		void BtPrevClick(object sender, EventArgs e)
		{
			FindPrev(tbFind.Text);
		}
		void BtNextClick(object sender, EventArgs e)
		{
			FindNext(tbFind.Text);
		}
		void DataGridView1Sorted(object sender, EventArgs e)
		{
			ShowRowIndex();
		}
		void ShowRowIndex()
		{
			foreach(DataGridViewRow row in dataGridView1.Rows)
			{
				row.HeaderCell.Value=(row.Index+1).ToString();
			}
		}
		void DataGridView1DataSourceChanged(object sender, EventArgs e)
		{
			ShowRowIndex();
		}
		void CmDeleteOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = dataGridView1.SelectedRows.Count <= 0;
		}
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(DataGridViewRow row in dataGridView1.SelectedRows)
			{
				(row.DataBoundItem as DataRowView).Row.Delete();
			}
			ShowRowIndex();
		}
		void BtReloadClick(object sender, EventArgs e)
		{
			MainFormLoad(null,null);
		}
		void CbShowPasswordCheckedChanged(object sender, EventArgs e)
		{
			if(cbShowPassword.Checked)
			{
				tbPassword.PasswordChar=tbNewPassword.PasswordChar='\0';
			}
			else
			{
				tbPassword.PasswordChar=tbNewPassword.PasswordChar='*';
			}
			dataGridView1.InvalidateColumn(dataGridView1.Columns["Password"].Index);
			dataGridView1.InvalidateColumn(dataGridView1.Columns["New Password"].Index);
		}
		void DataGridView1EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			string columnName=dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
			if( (columnName=="Password") || (columnName=="New Password") )
			{
				TextBox tb=e.Control as TextBox;
				if(tb!=null)
				{
					if(cbShowPassword.Checked)
						tb.PasswordChar='\0';
					else
						tb.PasswordChar='*';
				}
			}
		}
	}
}
