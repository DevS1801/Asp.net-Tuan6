using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Tuan6.Models
{
    public class ConnectProduct
    {
        public string constr = ConfigurationManager.ConnectionStrings["connect1"].ConnectionString;
        public List<Product> getData()
        {
            List<Product> lst = new List<Product>();
            using (SqlConnection con = new SqlConnection(constr))
            {

                SqlCommand cmd = new SqlCommand("sp_getSP", con);//proc
                cmd.CommandType = CommandType.StoredProcedure;//kiểu proc
                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Product pro = new Product();
                    pro.Masp = int.Parse(rd.GetValue(0).ToString());
                    pro.Tensp = rd.GetValue(1).ToString();
                    pro.Duongdan = rd.GetValue(2).ToString();
                    pro.Gia = float.Parse(rd.GetValue(3).ToString());
                    pro.Mota = rd.GetValue(4).ToString();
                    pro.Maloai = int.Parse(rd.GetValue(5).ToString());
                    lst.Add(pro);

                }
                con.Close();
                return lst;
            }

        }
        public List<Product> getDataAdapter()
        {
            List<Product> lstpro = new List<Product>();
            using(SqlConnection con= new SqlConnection(constr))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("sp_getSP_Loai", con);
                da.Fill(dt);
                foreach(DataRow row in dt.Rows)
                {
                    Product pro = new Product();
                    pro.Masp = (int)row["MaSP"];
                    pro.Tensp = row["TenSP"].ToString();
                    pro.Duongdan = row["DuongDan"].ToString();
                    pro.Gia = float.Parse(row["Gia"].ToString());
                    pro.Mota = row["MoTa"].ToString();
                    pro.Maloai = (int)row["MaLoai"];
                    pro.TenLoai = row["TenLoai"].ToString();
                    lstpro.Add(pro);
                }
                return lstpro;
            }    
        }
        public List<Product> searchproduct(string txt_search)
        {
            List<Product> lst = new List<Product>();
            using (SqlConnection con = new SqlConnection(constr))
            {

                SqlCommand cmd = new SqlCommand("select*from SanPham,Loai where TenSP like '%' +@ten+'%' and SanPham.MaLoai =Loai.MaLoai", con);
                cmd.CommandType = CommandType.Text;
                SqlParameter par = new SqlParameter("@ten", txt_search);
                cmd.Parameters.Add(par);
                con.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Product pro = new Product();
                    pro.Masp = int.Parse(rd.GetValue(0).ToString());
                    pro.Tensp = rd.GetValue(1).ToString();
                    pro.Duongdan = rd.GetValue(2).ToString();
                    pro.Gia = float.Parse(rd.GetValue(3).ToString());
                    pro.Mota = rd.GetValue(4).ToString();
                    pro.Maloai = int.Parse(rd.GetValue(5).ToString());
                    pro.TenLoai = rd.GetValue(7).ToString();
                    lst.Add(pro);

                }
                con.Close();
                return lst;
            }


        }

        public int delete(string id)
        {
            
            SqlConnection con = new SqlConnection(constr);
            int kt = 0;
            con.Open();
            string sql = "delete sanpham From sanpham where Masp="+id;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            //SqlParameter par = new SqlParameter("@masp", int.Parse(id));
            //cmd.Parameters.Add(par);
            kt = cmd.ExecuteNonQuery();
            con.Close();
            return kt;
        }

    }
}