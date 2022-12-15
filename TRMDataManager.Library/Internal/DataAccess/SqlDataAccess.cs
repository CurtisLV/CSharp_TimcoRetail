﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace TRMDataManager.Library.Internal.DataAccess
{
    public class SqlDataAccess : IDisposable, ISqlDataAccess
    {
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name);
        }

        public List<T> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionStringName
        )
        {
            string connectionString = GetConnectionString(connectionStringName);
            // Load data method using Dapper
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection
                    .Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure)
                    .ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            // Load data method using Dapper
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private readonly IConfiguration _config;

        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection
                .Query<T>(
                    storedProcedure,
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    transaction: _transaction
                )
                .ToList();

            return rows;
        }

        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            // Load data method using Dapper

            _connection.Execute(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure,
                transaction: _transaction
            );
        }

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _transaction = null;
            _connection?.Close();
            _connection = null;
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            _transaction = null;
            _connection?.Close();
            _connection = null;
        }

        public void Dispose()
        {
            CommitTransaction();
        }
    }
}
