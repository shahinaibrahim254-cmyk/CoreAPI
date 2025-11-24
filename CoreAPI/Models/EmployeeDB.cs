using System.Data;
using System.Data.SqlClient;
    
    namespace CoreAPI.Models
{
    public class EmployeeDB
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-25M3NCAO\SQLEXPRESS01;database=ASP_Core;Integrated security=true");
        public string InsertDB(EmployeeDTO objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_dbinsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empna", objcls.ename);
                cmd.Parameters.AddWithValue("@empaddr", objcls.eaddr);
                cmd.Parameters.AddWithValue("@empsal", objcls.esal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Inserted Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public Employee Selectprofiledb(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectprofile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]),//set
                        ename = sdr["Emp_Name"].ToString(),
                        eaddr = sdr["Emp_Address"].ToString(),
                        esal = sdr["Emp_Salary"].ToString(),
                    };

                }
                con.Close();
                return getdata;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }

        }
        public string UpdateDB(int id,Employee objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_profileupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.AddWithValue("@empna", objcls.ename);
                cmd.Parameters.AddWithValue("@empaddr", objcls.eaddr);
                cmd.Parameters.AddWithValue("@empsal", objcls.esal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Updated Succesffully Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string deletedb(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",id);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("ok......");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public List<Employee> selectdb()
        {
            var list = new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_selectall", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var obj = new Employee
                    {
                        eid = Convert.ToInt32(sdr["Emp_Id"]),//set
                        ename = sdr["Emp_Name"].ToString(),
                        eaddr = sdr["Emp_Address"].ToString(),
                        esal = sdr["Emp_Salary"].ToString(),


                    };
                    list.Add(obj);

                }
                con.Close();
                return list;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;

            }
        }
    }
}
