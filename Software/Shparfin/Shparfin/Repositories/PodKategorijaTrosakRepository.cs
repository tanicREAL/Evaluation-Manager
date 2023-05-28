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
    public class PodKategorijaTrosakRepository
    {
        public static List<PodKategorijaTrosak> GetPodKategorije()
        {
            List<PodKategorijaTrosak> podkategorije = new List<PodKategorijaTrosak>();
            string sql = "SELECT * FROM PodKategorijaTrosak";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                PodKategorijaTrosak podkategorija = CreateObject(reader);
                podkategorije.Add(podkategorija);
            }
            reader.Close();
            DB.CloseConnection();
            return podkategorije;
        }

        public static PodKategorijaTrosak CreateObject(SqlDataReader reader)
        {
            int idPodKategorijaTrosak = int.Parse(reader["IdPodKategorijaTrosak"].ToString());
            string naziv = reader["NazivPodKategorijaTrosak"].ToString();



            var podkategorija = new PodKategorijaTrosak
            {
                IdPodKategorijaTrosak = idPodKategorijaTrosak,
                Naziv = naziv

            };
            return podkategorija;

        }
    }
}

