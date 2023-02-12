using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDSinBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool edit = false;
        int id = 1;
        int rows = 0;

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Nombre")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Nombre";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if(txtLastName.Text == "Apellido")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.Black;
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Apellido";
                txtLastName.ForeColor = Color.Gray;
            }
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
            if(txtAge.Text == "0")
            {
                txtAge.Text = "";
                txtAge.ForeColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtAge.ForeColor = Color.Gray;
            txtLastName.ForeColor = Color.Gray;
            txtName.ForeColor = Color.Gray;
            //Style of btn save
            btnSave.Enabled = false;
            btnSave.BackColor = Color.Gray;
            btnSave.ForeColor = Color.White;
        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (txtAge.Text == "")
            {
                txtAge.Text = "0";
                txtAge.ForeColor = Color.Gray;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            edit = false;
            btnSave.Enabled = true;
            btnSave.BackColor = Color.RoyalBlue;
            btnSave.ForeColor = Color.White;
            //
            btnNew.Enabled = false;
            btnNew.BackColor = Color.Gray;
            btnNew.ForeColor = Color.White;
        }

        private void ClearTextBoxs()
        {
            txtAge.Text = "0";
            txtLastName.Text = "Apellido";
            txtName.Text = "Nombre";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                //Create an user
                int x = DvgData.Rows.Add();
                user user = new user();
                //..
                user.Id = id;
                user.Name = txtName.Text;
                user.Lastname = txtLastName.Text;
                user.Age = Convert.ToInt32(txtAge.Text);
                //..
                DvgData.Rows[x].Cells[0].Value = user.Id;
                DvgData.Rows[x].Cells[1].Value = user.Name;
                DvgData.Rows[x].Cells[2].Value = user.Lastname;
                DvgData.Rows[x].Cells[3].Value = user.Age;
                //
                ClearTextBoxs();
                id++;
                //Style of btn save
                btnSave.Enabled = false;
                btnSave.BackColor = Color.Gray;
                btnSave.ForeColor = Color.White;
                //Style of btn new
                btnNew.Enabled = true;
                btnNew.BackColor = Color.RoyalBlue;
                btnNew.ForeColor = Color.White;
            }
            else
            {
                if (DvgData.Rows.Count > 0)
                {
                    user user = new user();
                    //..
                    user.Name = txtName.Text;
                    user.Lastname = txtLastName.Text;
                    user.Age = Convert.ToInt32(txtAge.Text);
                    //..
                    DvgData.Rows[rows].Cells[1].Value = user.Name;
                    DvgData.Rows[rows].Cells[2].Value = user.Lastname;
                    DvgData.Rows[rows].Cells[3].Value = user.Age;
                    //
                    rows = 0;
                    ClearTextBoxs();
                    edit = false;
                    //Style of btn save
                    btnSave.Enabled = false;
                    btnSave.BackColor = Color.Gray;
                    btnSave.ForeColor = Color.White;
                    //Style of btn new
                    btnNew.Enabled = true;
                    btnNew.BackColor = Color.RoyalBlue;
                    btnNew.ForeColor = Color.White;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(DvgData.SelectedRows.Count > 0)
            {
                btnSave.Enabled = true;
                btnSave.BackColor = Color.RoyalBlue;
                btnSave.ForeColor = Color.White;
                //
                btnNew.Enabled = false;
                btnNew.BackColor = Color.Gray;
                btnNew.ForeColor = Color.White;
                edit = true;
                rows = DvgData.SelectedRows[0].Index;
                txtName.Text = DvgData.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = DvgData.CurrentRow.Cells[2].Value.ToString();
                txtAge.Text = DvgData.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(DvgData.SelectedRows.Count > 0)
            {
                int index = DvgData.SelectedRows[0].Index;
                DvgData.Rows.RemoveAt(index);
            }
        }
    }
}
