using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using static Dapper.SqlMapper;

namespace AspNet.Template.Data.Context
{
    public class DbContext : IDbContext
    {
        private readonly IDbConnection dbConnection;
        public DbContext()
        {
            dbConnection = new NpgsqlConnection("");
            if(dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
        }
        public IDbConnection GetConnection()
        {
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            return dbConnection;
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string query)
        {
            return dbConnection.QueryAsync<T>(query);
        }
        public Task<IEnumerable<T>> QueryAsync<T>(string query, IDynamicParameters param)
        {
            return dbConnection.QueryAsync<T>(query, param);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map)
        {
            return dbConnection.QueryAsync<TFirst, TSecond, TReturn>(query, map);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string query, IDynamicParameters param, Func<TFirst, TSecond, TReturn> map)
        {
            return dbConnection.QueryAsync<TFirst, TSecond, TReturn>(query, map, param);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map)
        {
            return dbConnection.QueryAsync<TFirst, TSecond, TThird, TReturn>(query, map);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string query, IDynamicParameters param, Func<TFirst, TSecond, TThird, TReturn> map)
        {
            return dbConnection.QueryAsync<TFirst, TSecond, TThird, TReturn>(query, map, param);
        }
    }
}