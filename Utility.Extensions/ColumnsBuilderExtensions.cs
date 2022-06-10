using Newtonsoft.Json;
using SQL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utility.Extensions
{
    public static class ColumnsBuilderExtensions
    {
        public static string GetCommaSeparatedColumns(this IEnumerable<string> properties)
        {
            var columnsBuilder = new StringBuilder();

            columnsBuilder.Append(string.Join(", ", properties));

            return columnsBuilder.ToString();
        }

        public static IEnumerable<string> GetColumns<TEntity>(this TEntity entity, SqlConfiguration sqlConfiguration, bool fetchJsonProperties = false, bool ignoreIdProperty = false, IEnumerable<string> ignoreProperties = null, bool forInsert = true)
        {
            ignoreProperties ??= Enumerable.Empty<string>();

            var roleProperties = Enumerable.Empty<string>();
            var idProperty = entity.GetType().GetProperty("Id");

            if (idProperty != null && !ignoreIdProperty)
            {
                var defaultIdTypeValue = idProperty.PropertyType == typeof(string) ? string.Empty : Activator.CreateInstance(idProperty.PropertyType);
                var idPropertyValue = idProperty.GetValue(entity, null);

                roleProperties = !idPropertyValue.Equals(defaultIdTypeValue)
                                    ? entity.GetType()
                                            .GetPublicPropertiesNames(x => !ignoreProperties.Any(y => x.Name == y))
                                    : forInsert
                                        ? entity.GetType()
                                                .GetPublicPropertiesNames(y => !y.Name.Equals("Id")
                                                                               && !ignoreProperties.Any(x => x == y.Name))
                                        : entity.GetType()
                                                .GetPublicPropertiesNames(x => !ignoreProperties.Any(y => x.Name == y));

            }
            else
            {
                if (!fetchJsonProperties)
                {
                    roleProperties = entity.GetType()
                                           .GetPublicPropertiesNames(y => !y.Name.Equals("Id")
                                                                          && !ignoreProperties.Any(x => x == y.Name));
                }
                else
                {

                    roleProperties = entity.GetType().GetProperties().SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute)).Cast<JsonPropertyAttribute>())
                                                                                .Select(prop => prop.PropertyName)
                                                                                .ToArray();


                }
                roleProperties = from s in roleProperties orderby s select s;
            }

            roleProperties = roleProperties.Select(y => string.Concat(sqlConfiguration.TableColumnStartNotation, y, sqlConfiguration.TableColumnEndNotation));

            return roleProperties;
        }

        public static string GetFilterdColumns<TEntity>(this TEntity entity, SqlConfiguration sqlConfiguration, bool fetchJsonProperties = false, bool ignoreIdProperty = false, IEnumerable<string> ignoreProperties = null, bool forInsert = true)
        {
            var dynamicFilter = " where ";

            ignoreProperties ??= Enumerable.Empty<string>();

            var roleProperties = Enumerable.Empty<string>();
            var idProperty = entity.GetType().GetProperty("Id");

            if (idProperty != null && !ignoreIdProperty)
            {
                var defaultIdTypeValue = idProperty.PropertyType == typeof(string) ? string.Empty : Activator.CreateInstance(idProperty.PropertyType);
                var idPropertyValue = idProperty.GetValue(entity, null);

                roleProperties = !idPropertyValue.Equals(defaultIdTypeValue)
                                    ? entity.GetType()
                                            .GetPublicPropertiesNames(x => !ignoreProperties.Any(y => x.Name == y))
                                    : forInsert
                                        ? entity.GetType()
                                                .GetPublicPropertiesNames(y => !y.Name.Equals("Id")
                                                                               && !ignoreProperties.Any(x => x == y.Name))
                                        : entity.GetType()
                                                .GetPublicPropertiesNames(x => !ignoreProperties.Any(y => x.Name == y));
            }

            else
            {
                if (!fetchJsonProperties)
                {
                    roleProperties = entity.GetType()
                    .GetPublicPropertiesNames(y => !y.Name.Equals("Id")
                    && !ignoreProperties.Any(x => x == y.Name));

                    roleProperties = from s in roleProperties orderby s select s;
                }
                else
                {
                    roleProperties = entity.GetType().GetProperties().Where(xx => xx.GetValue(entity, null) != null).SelectMany(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute)).Cast<JsonPropertyAttribute>())
                                                                                .Select(prop => prop.PropertyName)
                                                                                .ToArray();

                    var field = 0;
                    if (roleProperties.Count() > 0)
                    {
                        dynamicFilter = " where ";
                    }

                    var builder = new StringBuilder(dynamicFilter);

                    foreach (var strProp in roleProperties)
                    {
                        field++;

                        if (field == roleProperties.Count())
                        {
                            builder.AppendFormat(" {0} = {1} ", strProp, string.Format("{0}{1}", "@", strProp.ToTitleCase()));
                        }
                        else
                        {
                            builder.AppendFormat(" {0} = {1} and ", strProp, string.Format("{0}{1}", "@", strProp.ToTitleCase()));
                        }

                    }
                    dynamicFilter = builder.ToString();

                }
            }


            return dynamicFilter;
        }

    }
}
