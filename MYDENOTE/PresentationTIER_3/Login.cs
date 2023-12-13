﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Guna.UI2.WinForms;

namespace GUI
{
    public partial class Login : Form
    {
        UserBUS objUserBUS = new UserBUS();

        public Login()
        {
            InitializeComponent();
        }
        private void SignSignButton_Click(object sender, EventArgs e)
        {
            FillingFormLOGIN_container.Visible = false;
            LogSignTransition.ShowSync(FillingFormLOGIN_container);
        }
        private void LogCreateButton_Click(object sender, EventArgs e)
        {
            FillingFormLOGIN_container.Visible = true;
            LogSignTransition.HideSync(FillingFormLOGIN_container);
        }

        private void Login_BTN_Click(object sender, EventArgs e)
        {
            if(Username_login_txt.ToString() == "" || Password_login_txt.ToString() == "")
            {
                MessageBox.Show("Please fill in all the fields!");
            }
            else
            {
                UserBUS objUserBUS = new UserBUS();
                if (objUserBUS.checkLogin(Username_login_txt.Text, Password_login_txt.Text))
                {
                    MessageBox.Show("Login successful!");
                    this.Hide();
                    //new Home().Show();
                }
                else
                {
                    MessageBox.Show("Login failed!");
                }
            }

        }

        private void CreateAcc_btn_Click(object sender, EventArgs e)
        {
            if(Username_signup_txt.Text == "" || Password_signup_txt.Text == "")
            {
                if(Username_signup_txt.Text == "")
                {
                    Username_signup_txt.BorderColor = Color.Red;
                }
                if(Password_signup_txt.Text == "")
                {
                    Password_signup_txt.BorderColor = Color.Red;
                }
                if(Password_signup_txt.Text != rePassword_signup_txt.Text)
                {
                    MessageBox.Show("Passwords do not match!");
                    rePassword_signup_txt.BorderColor = Color.Red;
                }

                MessageBox.Show("Please fill in all the fields!");
            }
            else
            {
                try
                {
                    objUserBUS.AddUser(Username_signup_txt.Text, Password_signup_txt.Text);
                    MessageBox.Show("Account created successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
