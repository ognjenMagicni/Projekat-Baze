using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Takmicenje.AdditionalClasses;
using Takmicenje.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Takmicenje.Repository
{
    public class StudentRepository
    {
        static string accessDatabase = "Server=DESKTOP-J0Q22T8;Database=Takmicenje;Trusted_Connection=True;";

        public static DataTable getAllStudentByUsername(string username, int ID_Room)
        {
            DataTable dt = null;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Username,Name,Surname FROM Student WHERE Username LIKE @username "+"" +
                        "EXCEPT "+
                        "SELECT S.Username,S.Name,S.Surname FROM Student as S INNER JOIN StudentRoom as SR ON S.Username = SR.FK_Student WHERE FK_Room = @idroom";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", '%'+username+'%');
                    cmd.Parameters.AddWithValue("idroom", ID_Room);
                    string queryString = cmd.CommandText;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            return dt;
        }

        public static bool insertStudentRoom(int ID_Room,string username)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO StudentRoom(FK_Student,FK_Room)" +
                        " VALUES(@username,@idroom)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("idroom", ID_Room);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return result;
        }

        public static DataTable getAllStudentsOfRoom(int ID_Room)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT S.Username,S.Name,S.Surname FROM Student as S INNER JOIN StudentRoom AS SR ON SR.FK_Student=S.Username WHERE FK_Room=@idroom";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("idroom", ID_Room);
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
        public static bool insertStudent(Student s)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(accessDatabase))
                {
                    connection.Open();
                    string query = "INSERT INTO Student(Username,Name,Surname,Password)"+
                        " VALUES(@username,@name,@surname,@password)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username",s.username);
                    cmd.Parameters.AddWithValue("name",s.name);
                    cmd.Parameters.AddWithValue("surname",s.surname);
                    cmd.Parameters.AddWithValue("password",s.getPassword());
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public static Student getHashPasswordByUsername(string username, string password)
        {
            try
            {
                Student s = null;
                using (SqlConnection connection = new SqlConnection(accessDatabase))
                {

                    connection.Open();
                    string command = "Select * FROM Student WHERE Username=@username";
                    SqlCommand cmd = new SqlCommand(command, connection);
                    cmd.Parameters.AddWithValue("username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                            return null;
                        reader.Read();
                        s = new Student();
                        s.username = reader.GetString(0);
                        s.name = reader.GetString(1);
                        s.surname = reader.GetString(2);
                        string HashPassword = reader.GetString(3);
                        string hPassword = HashClass.HashFunction(password);

                        if (hPassword != HashPassword)
                        {
                            MessageBox.Show("Wrong password");
                            return null;
                        }
                        else
                        {
                            return s;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
