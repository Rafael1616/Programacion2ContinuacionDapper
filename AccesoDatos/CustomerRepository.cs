﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public List<Customers> ObtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                String sqlSelectAll = "";
                sqlSelectAll = sqlSelectAll + "SELECT [CustomerID] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[CompanyName] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[ContactName] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[ContactTitle] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[Address] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[City] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[Region] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[PostalCode] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[Country] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[Phone] " + "\n";
                sqlSelectAll = sqlSelectAll + "      ,[Fax] " + "\n";
                sqlSelectAll = sqlSelectAll + "  FROM [dbo].[Customers]";

                var cliente = conexion.Query<Customers>(sqlSelectAll).ToList();
                return cliente;
            }
        }

        public Customers ObtenerPorID(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                String selectPorID = "";
                selectPorID = selectPorID + "SELECT [CustomerID] " + "\n";
                selectPorID = selectPorID + "      ,[CompanyName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactName] " + "\n";
                selectPorID = selectPorID + "      ,[ContactTitle] " + "\n";
                selectPorID = selectPorID + "      ,[Address] " + "\n";
                selectPorID = selectPorID + "      ,[City] " + "\n";
                selectPorID = selectPorID + "      ,[Region] " + "\n";
                selectPorID = selectPorID + "      ,[PostalCode] " + "\n";
                selectPorID = selectPorID + "      ,[Country] " + "\n";
                selectPorID = selectPorID + "      ,[Phone] " + "\n";
                selectPorID = selectPorID + "      ,[Fax] " + "\n";
                selectPorID = selectPorID + "  FROM [dbo].[Customers] " + "\n";
                selectPorID = selectPorID + "  WHERE CustomerID = @CustomerID";

                var Cliente = conexion.QueryFirstOrDefault<Customers>(selectPorID, new { CustomerID = id });
                return Cliente;
            }

        }
    }
}
