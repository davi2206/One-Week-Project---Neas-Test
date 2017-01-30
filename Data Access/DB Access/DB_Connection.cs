using Data_Access_Server.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Data_Access.DB_Access
{
    /// <summary>
    /// Connects to the database
    /// Sends data to and retrieves data from the database
    /// </summary>
    class DB_Connection
    {
        string command = "";
        SqlCommand sqlCommand;

        public DB_Connection(string connectionString = @"Server=localhost\SQLExpress; Database=Neas Project; Integrated Security=true;")
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets all distrits in database, with all connected data
        /// </summary>
        /// <returns>List of District objects</returns>
        public List<District> GetAllDistricts()
        {
            List<District> districts = new List<District>();

            using (SqlConnection con = new SqlConnection())
            {

                try
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();
                }
                catch (Exception e)
                {
                    throw e;
                }

                try
                {
                    command = "SELECT * FROM Districts;";
                    sqlCommand = new SqlCommand(command, con);
                }
                catch (Exception e)
                {
                    throw e;
                }

                try
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            string nr = (string)reader[0];
                            string name = (string)reader[1];
                            string managerId = (string)reader[2];
                            Salesman manager = GetSalesman(managerId);
                            District district = new District(nr, name, manager);
                            district.Salesmen = GetSalesmenInDistrict(nr);
                            district.Stores = GetStoresInDistrict(nr);

                            districts.Add(district);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return districts;
        }

        /// <summary>
        /// Get a specific district
        /// </summary>
        /// <param name="nr">District number</param>
        /// <returns>District object</returns>
        public District GetDistrict(string nr)
        {
            District district = null;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format("SELECT * FROM Districts WHERE Nr='{0}';", nr);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[1];
                            string managerId = (string)reader[2];
                            Salesman manager = GetSalesman(managerId);
                            district = new District(nr, name, manager);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return district;
        }

        /// <summary>
        /// Get all salesmen in the given district
        /// </summary>
        /// <param name="districtNr">Number of the district</param>
        /// <returns>List of Salesman objects</returns>
        private List<Salesman> GetSalesmenInDistrict(string districtNr)
        {
            List<Salesman> salesmen = new List<Salesman>();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format(@"SELECT Salesman_Id FROM DistrictSalesman 
                                            WHERE District_Id='{0}';", districtNr);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = (string)reader[0];

                            Salesman s = GetSalesman(id);

                            salesmen.Add(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return salesmen;
        }

        /// <summary>
        /// Gets the Salesman with id
        /// </summary>
        /// <param name="salesmanId">Id of desired Salesman</param>
        /// <returns>Salesman object</returns>
        private Salesman GetSalesman(string salesmanId)
        {
            Salesman salesman = null;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format("SELECT * FROM Salesmen WHERE Id='{0}';", salesmanId);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = (string)reader[0];
                            string name = (string)reader[1];

                            salesman = new Salesman(id, name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return salesman;
        }

        /// <summary>
        /// Get all stores in given district
        /// </summary>
        /// <param name="districtNr">Nr of the district</param>
        /// <returns>List of Store objects</returns>
        private List<Store> GetStoresInDistrict(string districtNr)
        {
            List<Store> stores = new List<Store>();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format(@"SELECT Store_Id FROM DistrictStore 
                                            WHERE District_Nr='{0}';", districtNr);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = (string)reader[0];

                            Store s = GetStore(id);

                            stores.Add(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return stores;
        }

        /// <summary>
        /// Get Store with id
        /// </summary>
        /// <param name="storeId">Id of the desired store</param>
        /// <returns>Store object</returns>
        private Store GetStore(string storeId)
        {
            Store store = null;

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format("SELECT * FROM Stores WHERE Id='{0}';", storeId);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = (string)reader[0];
                            string name = (string)reader[1];

                            store = new Store(id, name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return store;
        }

        /// <summary>
        /// Get all available salesmen for the district
        /// </summary>
        /// <param name="excludeDistrict">Number of the curent district, to exclude salesmen allready connected</param>
        /// <returns>List of Salesman objects</returns>
        public List<Salesman> GetAvailableSalesmen(string excludeDistrict)
        {
            List<Salesman> stores = new List<Salesman>();

            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = ConnectionString;
                    con.Open();

                    command = string.Format(@"SELECT Salesmen.Id, Salesmen.Name 
                                                FROM Salesmen 
                                                INNER JOIN DistrictSalesman 
                                                ON Salesmen.Id=Salesman_Id 
                                                AND District_Id!='{0}' 
                                                AND Manager='0';", excludeDistrict);
                    sqlCommand = new SqlCommand(command, con);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = (string)reader[0];
                            string name = (string)reader[1];

                            Salesman s = new Salesman(id, name);

                            stores.Add(s);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return stores;
        }

        public bool UpdateDistrict(string districtNr, string salesmanId, bool manager)
        {
            bool worked = false;
            
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand command;
                SqlTransaction transaction;


                try
                {
                    con.Open();
                    command = con.CreateCommand();
                    transaction = con.BeginTransaction("");

                    command.Connection = con;
                    command.Transaction = transaction;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                try
                {
                    command.CommandText = string.Format(@"INSERT INTO DistrictSalesman 
                                                        VALUES({0}, {1}, {2});", 
                                                        salesmanId, districtNr, manager);
                    int rowsAffected = command.ExecuteNonQuery();

                    command.CommandText = string.Format(@"UPDATE Districts 
                                                        SET Manager={0}
                                                        WHERE Nr={1}; ", 
                                                        salesmanId, districtNr);
                    rowsAffected = command.ExecuteNonQuery();

                    transaction.Commit();
                    worked = true;
                }
                catch
                {
                    worked = false;
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex_rollback)
                    {
                        throw ex_rollback;
                    }
                }
            }
            
            return worked;
        }
    }
}
