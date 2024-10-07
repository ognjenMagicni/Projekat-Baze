using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takmicenje.Models;

namespace Takmicenje.Repository
{
    public  class RepositoryForAll
    {
        static string accessDatabase = "Server=DESKTOP-J0Q22T8;Database=Takmicenje;Trusted_Connection=True;";

        public static bool update(string table,string[] attributes, Object[] values, string[] where, object[] condition)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(accessDatabase))
            {
                try
                {
                    conn.Open();

                    //UPDATE
                    string query = "UPDATE "+table+" SET ";

                    //SET
                    for (int i = 0; i < attributes.Length; i++)
                    {
                        query += "@attrb" + i + " = @value" + i + ", ";
                    }
                    query = query.Substring(0, query.Length - 2);

                    //WHERE
                    query += " WHERE ";
                    for (int i = 0; i < where.Length; i++)
                    {
                        query += " @where" + i + " = @con" + i + " AND ";
                    }
                    query = query.Substring(0, query.Length - 4);

                    SqlCommand cmd = new SqlCommand(query, conn);

                    for (int i = 0; i < attributes.Length; i++)
                    {
                        cmd.Parameters.AddWithValue("attrb" + i, attributes[i]);
                        cmd.Parameters.AddWithValue("value" + i, values[i]);
                    }
                    for (int i = 0; i < where.Length; i++)
                    {
                        cmd.Parameters.AddWithValue("where" + i, where[i]);
                        cmd.Parameters.AddWithValue("con" + i, condition[i]);
                    }
                    
                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/
                    

                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }

        public static bool update1( float values,  int condition)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(accessDatabase))
            {
                try
                {
                    conn.Open();

                    //UPDATE
                    string query = "UPDATE Submit SET Accuracy  = @value  WHERE ID_Submit = @con";
                    SqlCommand cmd = new SqlCommand(query, conn);


                        cmd.Parameters.AddWithValue("value" , values);
                    
                        cmd.Parameters.AddWithValue("con" , condition);
                    

                    string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);


                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return result;
        }
        public static Object insert(string[] attributes, string table ,Object[] values, Object IdType,bool returnExist=false)
        {
            Object Id = null;
            using(SqlConnection conn = new SqlConnection(accessDatabase))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO " + table + "(";
                    foreach (string a in attributes)
                        query += a + ", ";
                    query = query.Substring(0, query.Length - 2) + ") ";
                    query += "VALUES(";
                    for (int i = 0; i < attributes.Length; i++)
                        query += "@par" + i + ",";
                    query = query.Substring(0, query.Length - 1) + ") ";
                    if(returnExist)
                        query += " SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    for (int i = 0; i < values.Length; i++)
                        cmd.Parameters.AddWithValue("par" + i, values[i]);
                    if(IdType.GetType()==typeof(int))
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                    else if(IdType.GetType() == typeof(string))
                        Id = Convert.ToString(cmd.ExecuteScalar());

                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            return Id;
        }

        //select - tu stavljas koje atribute selektujes, from je tabela, where je atribut, id
        public static DataTable getAllById(string[] select,string[] from, string[] keys,string[] where,Object[] id)
        {
            DataTable dt = null;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();

                    //SELECT
                    string query = "SELECT ";
                    foreach (string i in select)
                        query += " " + i + ", ";
                    query = query.Substring(0, query.Length - 2);

                    //FROM   tab1 id1 tab2 id2 tab3 id3   from tab1 inner join tab2 on tab1.id1=tab2.id2 inner join tab3 on tab2.id2=tab3.id3
                    query += " FROM " + from[0] + " "; 
                    for(int i = 0,j=0; i < from.Length; i++)
                    {
                        if (i == from.Length - 1)
                            break;
                        query += " INNER JOIN " + from[i + 1] + " ON " + from[i] + "." + keys[j] + "=" + from[i + 1] + "." + keys[j + 1];
                        j += 2;
                    }



                    //WHERE

                    if (where != null)
                    {
                        query += " WHERE " ;
                        for (int i = 0; i < where.Length; i++)
                            query += where[i] + "=@parameter" + Convert.ToString(i) + " and ";
                        query = query.Substring(0, query.Length - 4);
                    }
                    SqlCommand cmd = new SqlCommand(query, connection);
                    if(where != null)
                        for(int i=0;i<id.Length;i++)
                            cmd.Parameters.AddWithValue("parameter"+Convert.ToString(i), id[i]);

                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dt;

        }

        public static DataTable report(int ID_Room)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();

                    //SELECT
                    string query = "SELECT * FROM Submit INNER JOIN Room AS T ON T.ID_Room=Submit.FK_Room WHERE Submit.FK_Room = "+ Convert.ToString(ID_Room);
                    


                   
                    SqlCommand cmd = new SqlCommand(query, connection);
                    

                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dt;

        }

        public static DataTable report2(string username, int ID_Room)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();

                    //SELECT
                    string query = "SELECT Submit.FK_Student, Submit.FK_Task, InputOutput.Input, InputOutput.Output, SubmitiO.UserOutput, Submitio.Correct " +
                        " FROM Submit INNER JOIN SubmitIO ON Submit.ID_Submit=SubmitIO.FK_Submit INNER JOIN InputOutput ON SubmitIO.FK_IO=InputOutput.ID_IO " + 
                        " WHERE Submit.FK_Room=@id_room and Submit.FK_Student LIKE @username";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("id_room", ID_Room);
                    cmd.Parameters.AddWithValue("username", username);


                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        MessageBox.Show(Convert.ToString(parameter.ParameterName) + " " + parameter.Value.ToString());
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dt;

        }

        public static DataTable report3( int ID_Room)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();

                    //SELECT
                    string query = "SELECT * FROM Task as t INNER JOIN RoomTask as rt ON t.ID_Task=rt.FK_Task " +
                        " INNER JOIN Room as r on r.ID_Room=rt.FK_Room WHERE rt.FK_Room=@id_room";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("id_room", ID_Room);


                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        MessageBox.Show(Convert.ToString(parameter.ParameterName) + " " + parameter.Value.ToString());
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dt;

        }

        public static DataTable report4(string username)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(accessDatabase))
            {
                try
                {
                    connection.Open();

                    //SELECT
                    string query = "SELECT FK_Student,FK_Room,AVG(Accuracy) as Accuracy FROM Submit  "+
                        " WHERE FK_student = @username GROUP BY FK_Room,FK_Student";


                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("username", username);


                    /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        MessageBox.Show(Convert.ToString(parameter.ParameterName) + " " + parameter.Value.ToString());
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt = new DataTable();
                        dt.Load(reader);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            return dt;

        }

        //table - in each table it will delete, column - which column to serach for in WHERE, id is Key; multiple tables for relationships

        public static bool deleteById(string[] from, string[] keys, string[] where, Object[] id)
        {
            bool result = false;
            using(SqlConnection connection = new SqlConnection(accessDatabase))
            {
                connection.Open();
                
                //DELETE
                string query = "DELETE ";

                //FROM
                query += " FROM " + from[0] + " ";
                for (int i = 0, j = 0; i < from.Length; i++)
                {
                    if (i == from.Length - 1)
                        break;
                    query += " INNER JOIN " + from[i + 1] + " ON " + from[i] + "." + keys[j] + "=" + from[i + 1] + "." + keys[j + 1];
                    j += 2;
                }

                //WHERE
                if (where != null)
                {
                    query += " WHERE ";
                    for (int i = 0; i < where.Length; i++)
                        query += where[i] + "=@parameter" + Convert.ToString(i) + " and ";
                    query = query.Substring(0, query.Length - 4);
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                if (where != null)
                    for (int i = 0; i < id.Length; i++)
                        cmd.Parameters.AddWithValue("parameter" + Convert.ToString(i), id[i]);

                /*string queryString = cmd.CommandText;
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        queryString = queryString.Replace(parameter.ParameterName, parameter.Value.ToString());
                    }
                    MessageBox.Show("Query sent to the database: " + queryString);*/

                cmd.ExecuteNonQuery();

                
                result = true;
            }
            return result;
        }
    }
}
