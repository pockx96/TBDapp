using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TBDapp.Models
{
    public class SqliteHelper
    {
        SQLiteAsyncConnection bd;

        public SqliteHelper(string bdpath)
        {
            bd = new SQLiteAsyncConnection(bdpath);
            bd.CreateTableAsync<Clientes>().Wait();


        }

       
    }
}
