using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Models;

namespace Takmicenje.Repository
{
    public class RoomRepository
    {
        static string accessDatabase = "Server=DESKTOP-J0Q22T8;Database=Takmicenje;Trusted_Connection=True;";
        public static DataTable getAllRoomsOfAdmin(Administrator admin)
        {
            string username = admin.Username;
            DataTable dt = null;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Room WHERE FK_Admin=@username";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static DataTable getAllRoomsOfStudent(Student student)
        {
            string username = student.username;
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Room.ID_Room,Room.Name FROM Room INNER JOIN StudentRoom as SR ON Room.ID_Room=SR.FK_Room WHERE FK_Student=@username";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static bool insertRoom(Room r,Administrator admin)
        {
            bool result = false;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO ROOM(Name,FK_Admin) " +
                        "VALUES(@Name,@FK_Admin)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("Name", r.Name);
                    cmd.Parameters.AddWithValue("FK_Admin", admin.Username);
                    int affectedRow = cmd.ExecuteNonQuery();
                    if (affectedRow > 0)
                        result = true;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        public static bool deleteRoomById(int id)
        {
            bool result = false;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query2 = "DELETE FROM RoomTask WHERE FK_Room=@idroom";
                    SqlCommand cmd2 = new SqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("idroom", id);
                    int affectedRows2 = cmd2.ExecuteNonQuery();

                    string query = "DELETE FROM StudentRoom WHERE FK_Room=@idroom";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("idroom", id);
                    int affectedRows = cmd.ExecuteNonQuery();

                    string query1 = "DELETE FROM Room WHERE ID_Room=@idroom";
                    SqlCommand cmd1 = new SqlCommand(query1, connection);
                    cmd1.Parameters.AddWithValue("idroom", id);
                    int affectedRows1 = cmd1.ExecuteNonQuery();

                    

                    
                        result = true;
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return result;
        }
    }
}
