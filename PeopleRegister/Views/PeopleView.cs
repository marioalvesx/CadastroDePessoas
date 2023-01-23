using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeopleRegister.Views
{
    public partial class PeopleView : Form, IPeopleView
    {
        private string message;
        private bool isSuccessfull;
        private bool isEdit;

        public PeopleView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Add new people
            btnInclude.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "FrmPessoas";
            };
            // Edit
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "FrmPessoas - Alterar pessoa";
            };
            // Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Você confirma a exclusão dessa pessoa?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            // Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessfull)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
            // Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
            // Generate report
            btnReport.Click += delegate
            {
                CallReportEvent?.Invoke(this, EventArgs.Empty);
                using (var frm = new PeopleFormReport())
                {
                    frm.ShowDialog();
                }
            };

        }

        public string PeopleId
        {
            get { return txtPeopleId.Text; }
            set { txtPeopleId.Text = value; }
        }

        public string PeopleNome
        {
            get { return txtPeopleName.Text; }
            set { txtPeopleName.Text = value; }
        }
        public string PeopleTelefone
        {
            get { return txtPeoplePhone.Text; }
            set { txtPeoplePhone.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessfull
        {
            get { return isSuccessfull; }
            set { isSuccessfull = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler CallReportEvent;

        public void SetPeopleListBindingSource(BindingSource peopleList)
        {
            dataGridView1.DataSource = peopleList;
        }

    }
}
