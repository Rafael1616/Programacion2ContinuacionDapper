﻿using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnObtnerId_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerPorID(tboxObtenerID.Text);
            dgvCustomers.DataSource = new List<Customers> { cliente };

            if (cliente != null)
            {
                RellenarForm(cliente);
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.insertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txbCustomerId.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text,
            };
            return nuevo;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var clienteActualizado = CrearCliente();
            var actualizados = customerR.ActualizarCliente(clienteActualizado);
            var cliente = customerR.ObtenerPorID(clienteActualizado.CustomerID);
            dgvCustomers.DataSource = new List<Customers> { cliente };


            MessageBox.Show($"{actualizados} filas actualizadas , { clienteActualizado.CustomerID}");
        }

        private void RellenarForm(Customers customers)
        {
            txbCustomerId.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            txbAddress.Text = customers.Address;
        }

    }
}
