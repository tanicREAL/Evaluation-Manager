﻿using DBLayer;
using Shparfin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shparfin.Repositories
{
    public class KategorijaTrosakRepository
    {
        public static List<KategorijaTrosak> GetKategorije()
        {
            List<KategorijaTrosak> kategorije = new List<KategorijaTrosak>();
            string sql = "SELECT * FROM KategorijaTrosak";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                KategorijaTrosak kategorija = CreateObject(reader);
                kategorije.Add(kategorija);
            }
            reader.Close();
            DB.CloseConnection();
            return kategorije;
        }

        public static KategorijaTrosak GetKategorija(int id)
        {
            KategorijaTrosak kategorija = new KategorijaTrosak();
            string sql = $"SELECT * FROM KategorijaTrosak WHERE idKategorijaTrosak = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                kategorija = CreateObject(reader);
                
            }
            reader.Close();
            DB.CloseConnection();
            return kategorija;
        }

        public static KategorijaTrosak CreateObject(SqlDataReader reader)
        {
            int idKategorijaTrosak = int.Parse(reader["idKategorijaTrosak"].ToString());
            string naziv = reader["nazivKategorijaTrosak"].ToString();
            
            

            var kategorija = new KategorijaTrosak
            {
                IdKategorijaTrosak = idKategorijaTrosak,
                Naziv = naziv
                
            };
            return kategorija;

        }
    }
}
