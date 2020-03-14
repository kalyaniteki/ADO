using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOassignment
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-80R3HO1\SQLEXPRESS;Initial Catalog=practiceDb;User ID=sa;Password=pass@word1");
        SqlCommand cmd = null;
        public void Add(int id,string name,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("Insert into product values(@id,@name,@price,@stock)",con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

        }
        public void Get(int pid)
        {
            cmd = new SqlCommand("select * from product where id=@pid", con);
            cmd.Parameters.AddWithValue("@pid", pid);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                Console.WriteLine("ID:{0},Name:{1},Price:{2},Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);

            }
            else
            {
                Console.WriteLine("Invalid id");
            }

        }
        public void GetAll()
        {
            try
            {
                cmd = new SqlCommand("select * from product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        Console.WriteLine("ID:{0},Name:{1},Price:{2},Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);
                    }
                }

                else
                    Console.WriteLine("Table empty");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        public void delete(int pid)
        {
            try
            { 
            cmd = new SqlCommand("Delete from product where id=@pid ", con);
            cmd.Parameters.AddWithValue("@pid",pid);
            con.Open();
            cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }


        }
       public void update(int pid,int price,int stock)
        {
            try
            {
                cmd = new SqlCommand("update product set price=@price,stock=@stock where id=@pid",con);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }



        }


        static void Main(string[] args)
        {
            Program p = new Program();
            int id, price, stock;
            string name;
             id = int.Parse(Console.ReadLine());
            //name = Console.ReadLine();
            price = int.Parse(Console.ReadLine());
            stock = int.Parse(Console.ReadLine());
            // p.Add(id, name, price, stock);
            p.update(id, price, stock);
            //p.Get(id);
            //   p.GetAll();
           // p.delete(id);
            Console.ReadKey();
        }
    }
}
