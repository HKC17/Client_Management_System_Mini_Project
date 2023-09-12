using Microsoft.Data.SqlClient;

namespace ClientMangementSystem.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public static List<Client> GetAllClient()
        {
            List<Client> lst = new List<Client>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from clients ";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lst.Add(new Client { ClientId = dr.GetInt32(0), Name = dr.GetString(1), Address = dr.GetString(2), Email = dr.GetString(3), Mobile = dr.GetString(4) });
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lst;
        }
        public static Client GetSingleClient(int ClientId)
        {
            Client obj = new Client();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from clients where clientId=@ClientId";
                cmd.Parameters.AddWithValue("@ClientId", ClientId);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj.ClientId = dr.GetInt32(0);
                    obj.Name = dr.GetString(1);
                    obj.Address = dr.GetString(2);
                    obj.Email = dr.GetString(3);
                    obj.Mobile = dr.GetString(4);
                }
                else
                {
                    obj = null;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }
        public static void InsertClient(Client obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into clients values(@ClientId,@Name,@Address,@Email,@Mobile)";

                cmd.Parameters.AddWithValue("@ClientId", obj.ClientId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


        public static void UpdateClient(Client obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update clients set name=@Name, address=@Address, email=@Email, mobile = @Mobile  where clientId =@ClientId";

                cmd.Parameters.AddWithValue("@ClientId", obj.ClientId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Mobile", obj.Mobile);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void DeleteClient(int ClientId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from clients where clientId =@ClientId";

                cmd.Parameters.AddWithValue("@ClientId", ClientId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}

