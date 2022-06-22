using System;
using System.Collections.Generic;
using System.Data;

namespace Utility.Extensions
{
    public static class DataTableExtensions
    {
        public static List<T> CreateListFromTable<T>(this DataTable tbl) where T : new()
        {
            // define return list
            var lst = new List<T>();

            // go through each row
            foreach (DataRow r in tbl.Rows)
            {
                // add to the list
                lst.Add(CreateItemFromRow<T>(r));
            }

            // return the list
            return lst;
        }
        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            var item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }
        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                var p = item.GetType().GetProperty(c.ColumnName);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {

                    if (p.PropertyType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(row[c].ToString(), out DateTime dateTime))
                        {

                            p.SetValue(item, dateTime, null);
                        }

                    }
                    else
                    {
                        p.SetValue(item, row[c], null);
                    }
                }
            }
        }
    }
}
