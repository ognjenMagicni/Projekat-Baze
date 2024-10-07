using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.AdditionalClasses;
using Takmicenje.Models;

namespace Takmicenje.Repository
{
    public class AdministratorRepository
    {
        static string accessDatabase = "Server=DESKTOP-J0Q22T8;Database=Takmicenje;Trusted_Connection=True;";
        public static Administrator getHashPasswordByUsername(string username,string password)
        {
            try
            {
                Administrator admin = null;
                using (SqlConnection connection = new SqlConnection(accessDatabase))
                {

                    connection.Open();
                    string command = "Select * FROM Administrator WHERE Username=@username";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                            return null;
                        reader.Read();
                        admin = new Administrator();
                        admin.Username = reader.GetString(0);
                        admin.Name = reader.GetString(1);
                        admin.Surname = reader.GetString(2);
                        admin.HashPassword = reader.GetString(3);
                        string hPassword = HashClass.HashFunction(password);

                        if (hPassword != admin.HashPassword)
                        {
                            MessageBox.Show("Wrong password");
                            return null;
                        }
                        else
                        {
                            return admin;
                        }
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
