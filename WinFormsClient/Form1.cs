using System;
using System.Net;
using System.ServiceModel;
using System.Windows.Forms;
using WinFormsHost.BookReference;

namespace WinFormsHost
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.Ping();
				client.Close();
				MessageBox.Show(ret.Result.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				BookServiceClient client = new BookServiceClient();
				var ret = client.GetAllBook();
				client.Close();
				MessageBox.Show(ret.Data.ToString());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
