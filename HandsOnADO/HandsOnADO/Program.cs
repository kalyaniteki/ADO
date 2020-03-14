using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HandsOnADO
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-80R3HO1\SQLEXPRESS;Initial Catalog=practiceDb;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add()
        {
            try
            {
                cmd = new SqlCommand("Insert into project values(@no,@name,@budget)", con);
                //passing values to parameters
                cmd.Parameters.AddWithValue("@no", "P8");
                cmd.Parameters.AddWithValue("@name", "ddfg");
                cmd.Parameters.AddWithValue("@budget", 12222);
                // cmd.Parameters.AddWithValue("@pro_date",DateTime.Parse("12.3.2019") );
                con.Open();//to open connection
                cmd.ExecuteNonQuery();//insert,upadte,delete(execute dml queries)
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();//close connection
            }

        }
        public void GetProjectIdBy(string pno)
        {
            cmd = new SqlCommand("select * from project where pro_no=@pno", con);
            cmd.Parameters.AddWithValue("@pno", pno);
            con.Open();
           SqlDataReader dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                //read records in datareader
                dr.Read();//read only one record
                Console.WriteLine("ID:{0} Name:{1} Budget:{2}", dr["pro_no"], dr["pro_name"], dr["budget"]);
            }
            else
                Console.WriteLine("Invalid project ID");
        }
        public void GetAllProjects()
        {
            try
            {
                cmd = new SqlCommand("select * from project", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Console.WriteLine("ID:{0} Name:{1} Budget:{2}", dr["pro_no"], dr["pro_name"], dr["budget"]);
                    }
                }

                else
                    Console.WriteLine("Table empty");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            }
        
        static void Main(string[] args)
        {
            Program obj = new Program();
            //  obj.Add();
            //obj.GetProjectIdBy("P8");
            obj.GetAllProjects();
            Console.ReadKey();

        }
    }
}
