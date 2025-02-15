﻿using Data.Db.Service.Interface;
using Data.Db.Service.Model;
using SQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility.Extensions;

namespace Data.Db.Service
{
    public class DataDbConfigurationService : IDataDbConfigurationService
    {
        private readonly DBService dBService = new();

        public async Task<int> AddDataAsync<TRequest>(DataDbConfigSettings<TRequest> configSettings) where TRequest : new()
        {
            var _sqlConfiguration = new DataDbQueryConfiguration(configSettings.TableEnums);

            var columns = configSettings.Request.GetColumns(_sqlConfiguration, fetchJsonProperties: true);
            var colvalue = configSettings.Request.GetColumns(_sqlConfiguration, fetchJsonProperties: false);

            var valuesArray = new List<string>(columns.Count());
            valuesArray = valuesArray.InsertQueryValuesFragment(_sqlConfiguration.ParameterNotation, colvalue);

            var query = _sqlConfiguration.InsertQuery
                                         .ReplaceInsertQueryParameters(_sqlConfiguration.SchemaName,
                                                                       _sqlConfiguration.TableName,
                                                                       columns.GetCommaSeparatedColumns(),
                                                                       string.Join(", ", valuesArray));


            return await dBService.ExecuteAsync(ConnectionString: configSettings.DbConnection, sql: query, parameter: configSettings.Request);
        }

        public async Task<IEnumerable<TResponce>> GetDatasAsync<TRequest, TResponce>(DataDbConfigSettings<TRequest> configSettings) where TRequest : new()
        {
            string query = configSettings.PlainQuery;

            if (string.IsNullOrEmpty(query))
            {
                var _sqlConfiguration = new DataDbQueryConfiguration(configSettings.TableEnums);

                var filteredQuery = configSettings.Request.GetFilterdColumns(_sqlConfiguration, fetchJsonProperties: true, ignoreIdProperty: true);

                query = _sqlConfiguration.SelectQuery
                                            .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
                                                                    _sqlConfiguration.TableName,
                                                                    _sqlConfiguration.ParameterNotation,
                                                                    new string[] { },
                                                                    new string[] { },
                                                                    filteredQuery);
            }

            return await dBService.QueryAsync<TResponce, TRequest>(ConnectionString: configSettings.DbConnection, sql: query, parameter: configSettings.Request);
        }


        public async Task<TResponce> GetDataAsync<TRequest, TResponce>(DataDbConfigSettings<TRequest> configSettings) where TRequest : new()
        {
            string query = configSettings.PlainQuery;

            if (string.IsNullOrEmpty(query))
            {
                var _sqlConfiguration = new DataDbQueryConfiguration(configSettings.TableEnums);

                var filteredQuery = configSettings.Request.GetFilterdColumns(_sqlConfiguration, fetchJsonProperties: true, ignoreIdProperty: true);

                query = _sqlConfiguration.SelectQuery
                                            .ReplaceQueryParameters(_sqlConfiguration.SchemaName,
                                                                    _sqlConfiguration.TableName,
                                                                    _sqlConfiguration.ParameterNotation,
                                                                    new string[] { },
                                                                    new string[] { },
                                                                    filteredQuery);
            }
            return await dBService.QueryFirstOrDefaultAsync<TResponce, TRequest>(ConnectionString: configSettings.DbConnection, sql: query, parameter: configSettings.Request);
        }

        public async Task<int> UpdateDataAsync<TRequest>(DataDbConfigSettings<TRequest> configSettings) where TRequest : new()
        {
            //var _sqlConfiguration = new DataDbQueryConfiguration(configSettings.TableEnums);
            //string query = configSettings.PlainQuery;
            // var columns = configSettings.Request.GetColumns(_sqlConfiguration, fetchJsonProperties: true);
            //var colvalue = configSettings.Request.GetColumns(_sqlConfiguration, fetchJsonProperties: false);

            //var valuesArray = new List<string>(columns.Count());
            //valuesArray = valuesArray.InsertQueryValuesFragment(_sqlConfiguration.ParameterNotation, colvalue);




            //var columns = configSettings.Request.GetColumns(_sqlConfiguration, ignoreIdProperty: true);
            //var colvalue = configSettings.Request.GetColumns(_sqlConfiguration, fetchJsonProperties: false);
            //var valuesArray = new List<string>(columns.Count());
            //var setFragment = valuesArray.UpdateQuerySetFragment(_sqlConfiguration.ParameterNotation);

            //var query = _sqlConfiguration.UpdateRoleQuery
            //                             .ReplaceUpdateQueryParameters(_sqlConfiguration.SchemaName,
            //                                                           _sqlConfiguration.TableName,
            //                                                           setFragment,
            //                                                           $"{_sqlConfiguration.ParameterNotation}Id");



            return await dBService.ExecuteAsync(ConnectionString: configSettings.DbConnection, sql: configSettings.PlainQuery, parameter: configSettings.Request);
        }


    }
}
