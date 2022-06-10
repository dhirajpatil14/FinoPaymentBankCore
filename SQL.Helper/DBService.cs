using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQL.Helper
{
    public class DBService
    {
        public DBService()
        {

        }

        public async Task<IEnumerable<TResponce>> QueryAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QueryAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QueryFirstAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QueryFirstAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QueryFirstAsync<TResponce>(string ConnectionString, string sql)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QueryFirstAsync<TResponce>(sql, null);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QuerySingleAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QuerySingleAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QuerySingleAsync<TResponce>(string ConnectionString, string sql)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();


            try
            {
                var result = await sqlConnection.QuerySingleAsync<TResponce>(sql, null);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QueryFirstOrDefaultAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QueryFirstOrDefaultAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TResponce> QueryFirstOrDefaultAsync<TResponce>(string ConnectionString, string sql)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QueryFirstOrDefaultAsync<TResponce>(sql, null);

                return result;
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }

        public async Task<TResponce> QuerySingleOrDefaultAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QuerySingleOrDefaultAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<TResponce> QuerySingleOrDefaultAsync<TResponce>(string ConnectionString, string sql)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.QuerySingleOrDefaultAsync<TResponce>(sql, null);

                return result;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<int> ExecuteAsync<TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            try
            {

                var result = await sqlConnection.ExecuteAsync(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<int> ExecuteAsync<TRequest>(string ConnectionString, string sql)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.ExecuteAsync(sql, null);

                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<TResponce> ExecuteScalarAsync<TResponce, TRequest>(string ConnectionString, string sql, TRequest parameter)
        {
            using IDbConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            try
            {
                var result = await sqlConnection.ExecuteScalarAsync<TResponce>(sql, parameter);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
