using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace luyenbuoi1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sqlcon;
        SqlDataAdapter sqlda;
        DataSet ds;
        public void ketnoi()
        {
            string ketnoi;
            ketnoi = "Data Source=Lap-Tuan-Anh;Initial Catalog=qlhv;Integrated Security=True;Encrypt=False";
            //ketnoi = "server = Lap-Tuan-Anh; database = qlhv; Integrated Security=True ";
            sqlcon= new SqlConnection(ketnoi);
            sqlcon.Open();
        }
        public void hienthi()
        {
            ketnoi();
            string sql = "select *from hocvien";
            sqlda = new SqlDataAdapter(sql, sqlcon);
            ds = new DataSet();
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmahv.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtthv.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtgioitinh.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtquequan.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdiachi.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString(); ;

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            ketnoi();
            //float gt = float.Parse(txtgioitinh.Text);
            //float qq = float.Parse(txtquequan.Text);
            //float dc = gt + qq;
            string sql = "insert into hocvien values(@mahv,@tenhv,@gioitinh,@quequan,@diachi)";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("mahv", txtmahv.Text);
            sqlcom.Parameters.AddWithValue("tenhv", txtthv.Text);
            sqlcom.Parameters.AddWithValue("gioitinh", txtgioitinh.Text);
            sqlcom.Parameters.AddWithValue("quequan", txtquequan.Text);
            sqlcom.Parameters.AddWithValue("diachi", txtdiachi.Text);

            //sqlcom.Parameters.AddWithValue("diachi", dc);
            int n = sqlcom.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Ban da them thanh cong ");
                hienthi();

            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
           



            ketnoi();
            string sql = "update  hocvien set tenhv=@tenhv , gioitinh=@gioitinh,quequan=@quequan,diachi=@diachi where mahv =@mahv";
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.AddWithValue("mahv", txtmahv.Text);
            sqlcom.Parameters.AddWithValue("tenhv", txtthv.Text);
            sqlcom.Parameters.AddWithValue("gioitinh", txtgioitinh.Text);
            sqlcom.Parameters.AddWithValue("quequan", txtquequan.Text);
             sqlcom.Parameters.AddWithValue("diachi", txtdiachi.Text);
            
            sqlcom.ExecuteNonQuery();

            MessageBox.Show("Ban da Sua thanh cong ");
            hienthi();


        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult tl;
            tl = MessageBox.Show("Ban Co Muon Xoa Khong ?","Xoa Du Lieu",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                ketnoi();
                string sql ="delete from hocvien where mahv='"+txtmahv.Text+"'";
                SqlCommand sqlcom = new SqlCommand( sql, sqlcon);
                sqlcom.ExecuteNonQuery();
                hienthi();

            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "select *from hocvien order by mahv ASC";
            sqlda = new SqlDataAdapter(sql, sqlcon);
            ds = new DataSet();
            sqlda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
    }

}
