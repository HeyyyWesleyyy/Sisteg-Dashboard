﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisteg_Dashboard
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handlerparam = base.CreateParams;
                handlerparam.ExStyle |= 0x02000000;
                return handlerparam;
            }
        }

        private void pcb_btnMain_MouseEnter(object sender, EventArgs e)
        {
            this.pcb_btnMain.Image = Properties.Resources.btn_main_active;
        }

        private void pcb_btnMain_MouseLeave(object sender, EventArgs e)
        {
            this.pcb_btnMain.Image = Properties.Resources.btn_main;
        }

        private void pcb_btnMain_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Main>().Count() == 0)
            {
                Main main = new Main();
                main.Show();
                this.Close();
            }
        }

        private void pcb_btnClient_MouseEnter(object sender, EventArgs e)
        {
            this.pcb_btnClient.Image = Properties.Resources.btn_client_active;
        }

        private void pcb_btnClient_MouseLeave(object sender, EventArgs e)
        {
            this.pcb_btnClient.Image = Properties.Resources.btn_client;
        }

        private void pcb_btnClient_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Client>().Count() == 0)
            {
                Client client = new Client();
                client.Show();
                this.Close();
            }
        }

        private void pcb_btnBudget_MouseEnter(object sender, EventArgs e)
        {
            this.pcb_btnBudget.Image = Properties.Resources.btn_budget_active;
        }

        private void pcb_btnBudget_MouseLeave(object sender, EventArgs e)
        {
            this.pcb_btnBudget.Image = Properties.Resources.btn_budget;
        }

        private void pcb_btnBudget_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Budget>().Count() == 0)
            {
                Budget budget = new Budget();
                budget.Show();
                this.Close();
            }
        }

        private void pcb_btnConfig_MouseEnter(object sender, EventArgs e)
        {
            this.pcb_btnConfig.Image = Properties.Resources.btn_config_active;
        }

        private void pcb_btnConfig_MouseLeave(object sender, EventArgs e)
        {
            this.pcb_btnConfig.Image = Properties.Resources.btn_config;
        }

        private void pcb_btnConfig_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Config>().Count() == 0)
            {
                Config config = new Config();
                config.Show();
                this.Close();
            }
        }
    }
}
