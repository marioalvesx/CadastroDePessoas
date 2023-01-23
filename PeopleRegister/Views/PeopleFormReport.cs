using Microsoft.Reporting.WinForms;
using PeopleRegister.Models;
using PeopleRegister.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeopleRegister.Views
{
    public partial class PeopleFormReport : Form
    {
        public PeopleFormReport()
        {
            InitializeComponent();

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=teste_cadastros;Integrated Security=True; Encrypt=False;");
            SqlCommand command = new SqlCommand("SELECT * FROM pessoas", connection);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = projectDirectory + "/views/PeopleReport.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();

        }
    }
}
