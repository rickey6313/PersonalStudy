using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Portfolio
{
    class SqlManager
    {
        private static SqlManager _instance;
        public static SqlManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlManager();
                }
                return _instance;
            }
        }

        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        private SqlCommandBuilder _builder;
        private DataSet _dataSet;

        public void Init()
        {
            
            string connStr = Properties.Resources.ERPDBConnectionString;            
            _conn = new SqlConnection();
            _conn.ConnectionString = connStr;
            string userInfoSelect = "select * from UserInfo";
            _dataSet = new DataSet();
            _adapter = new SqlDataAdapter(userInfoSelect, _conn);
            _adapter.Fill(_dataSet, "UserInfo");
            _builder = new SqlCommandBuilder(_adapter);
        }

        public int SelectTable(string tableName)
        {
            _dataSet = new DataSet();

            string select = 
                $"select " +
                $"*" +
                $"from {tableName}";
            _adapter = new SqlDataAdapter(select, _conn);
            int fillRow = _adapter.Fill(_dataSet, tableName);
            return fillRow;
        }

        public int SelectTable(string tableName, string sql)
        {
            _dataSet = new DataSet();
            _adapter = new SqlDataAdapter(sql, _conn);
            int fillRow = _adapter.Fill(_dataSet, tableName);
            return fillRow;
        }

        public void SetBuilder(string tableName)
        {            
            switch (tableName)
            {
                case "UserInfo":
                    string select = $"select * from {tableName}";
                    _adapter = new SqlDataAdapter(select, _conn);
                    _dataSet = new DataSet();
                    _builder = new SqlCommandBuilder(_adapter);
                    _adapter.Fill(_dataSet, tableName);
                    break;
            }            
        }

        public int InsertCommand(string tableName, string id, string pwd, string name, int part, int auth, int rank, string email, string phone1, string phone2, string addr1, string addr2, DateTime date)
        {
            DataRow row = _dataSet.Tables[tableName].NewRow();
            row["userId"] = id;
            row["userPwd"] = pwd;
            row["userName"] = name;
            row["part"] = part;
            row["authorityGrade"] = auth;
            row["rankGrade"] = rank;
            row["email"] = email;
            row["phoneNumber1"] = phone1;
            row["phoneNumber2"] = phone2;
            row["address1"] = addr1;
            row["address2"] = addr2;
            row["registerDate"] = date;
            _dataSet.Tables[tableName].Rows.Add(row);
            int returnValue = _adapter.Update(_dataSet, tableName);
            System.Console.WriteLine($"returnValue : {returnValue}");
            return returnValue;
        }

        public void RemoveCommand(string tableName, string uniqueCol, int removeRow)
        {
            SetBuilder(tableName);
            string filter = $"{uniqueCol} = {removeRow}";
            DataRow[] find = _dataSet.Tables[tableName].Select(filter);
            find[0].Delete();
            _adapter.Update(_dataSet, tableName);
            _dataSet.Clear();
            //_adapter.Fill(_dataSet, tableName);
        }

        public DataTable GetDataTable(string tableName)
        {   
            return _dataSet.Tables[tableName];
        }

        public void SetDataSet(DataSet data)
        {
            _dataSet = data;
        }
    }
}


