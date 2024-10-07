using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Takmicenje.Repository
{
    public class TaskRepository
    {
        static string accessDatabase = "Server=DESKTOP-J0Q22T8;Database=Takmicenje;Trusted_Connection=True;";

        public static DataTable getAllTaskByTitle(string title, int ID_Room)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ID_Task,Title FROM Task WHERE Title LIKE @title " + "" +
                        "EXCEPT " +
                        "SELECT T.ID_Task,T.Title FROM Task as T INNER JOIN RoomTask as RT ON T.ID_Task = RT.FK_Task WHERE FK_Room = @idroom";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("title", '%' + title + '%');
                    cmd.Parameters.AddWithValue("idroom", ID_Room);
                    string queryString = cmd.CommandText;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return dt;
        }
    }
}
