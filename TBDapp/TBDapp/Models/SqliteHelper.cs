﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TBDapp.Models
{
    public class SqliteHelper
    {
        SQLiteAsyncConnection bd;

        public SqliteHelper(string bdpath)
        {
            bd = new SQLiteAsyncConnection(bdpath);
            bd.CreateTableAsync<Materiales>().Wait();
            bd.CreateTableAsync<Clientes>().Wait();

        }

        public Task<int> Savemateriales(Materiales mat)
        {
            if (mat.id_material==0)
            {
                return bd.InsertAsync(mat);
            }
            else
            {
                return null;
            }
           
        }

        /// <summary>
        /// Retorna toda la tabla de materiales
        /// </summary>
        /// <returns></returns>
        public Task<List<Materiales>> GetMateriales()
        {
            return bd.Table<Materiales>().ToListAsync();
        }

        public Task<Materiales> GetMaterialesByid(int idmaterial)
        {
            return bd.Table<Materiales>().Where(a => a.id_material == idmaterial).FirstOrDefaultAsync();
        }



    }
}
