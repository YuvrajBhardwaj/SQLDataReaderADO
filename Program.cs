using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SQLDataReaderADO
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from employee_tbl";
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();

            using (SqlDataReader dr = cmd.ExecuteReader()) 
            { 
                while (dr.Read())
                {
                    Console.WriteLine("ID: "+dr["id"]+" ,Name: "+dr["name"]+" ,gender: "+dr["gender"]+" ,Age: "+dr["Age"]+" ,Salary: "+dr["salary"]+" ,city: "+dr["city"]); //dr[indexer=column name]
                    //we can also write like this: dr[indexer=index location (1,2,3,4...)] concatenation syntax
                    Console.WriteLine("ID: " + dr[0] + " ,Name: " + dr[1] + " ,gender: " + dr[2] + " ,Age: " + dr[3] + " ,Salary: " + dr[4] + " ,city: " + dr[5]); //dr[indexer=column name]
                    Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}, Age: {3}, Salary: {4}, City: {5}",dr["id"], dr["name"], dr["gender"], dr["Age"], dr["salary"], dr["city"]); //placeholder syntax
                }
            }
            //SqlDataReader dr = cmd.ExecuteReader();
            con.Close();
            Console.ReadLine();
        }
    }
}
