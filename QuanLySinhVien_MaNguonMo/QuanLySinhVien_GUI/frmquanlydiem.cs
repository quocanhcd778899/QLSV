﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien_GUI
{
    public partial class frmquanlydiem : Form
    {
        public frmquanlydiem()
        {
            InitializeComponent();
        }
        int dem = 0;
        int row;
        private void frmquanlydiem_Load(object sender, EventArgs e)
        {
            cbbMaHK.DataSource = QuanLySinhVien_DAL.Data.DS_HOCKY();
            cbbMaHK.DisplayMember = "MaHK";
            cbbMaHK.ValueMember = "MaHK";

            cbbMaGV.DataSource = QuanLySinhVien_DAL.Data.DS_GIANGVIEN();
            cbbMaGV.DisplayMember = "MaGV";
            cbbMaGV.ValueMember = "MaGV";

            cbbMaMH.DataSource = QuanLySinhVien_DAL.Data.DS_MONHOC();
            cbbMaMH.DisplayMember = "MaMH";
            cbbMaMH.ValueMember = "MaMH";

            cbbMaSV.DataSource = QuanLySinhVien_DAL.Data.DS_SINHVIEN1();
            cbbMaSV.DisplayMember = "MaSV";
            cbbMaSV.ValueMember = "MaSV";

            dgvKetQua.DataSource = QuanLySinhVien_DAL.Data.DS_DIEM();
            dem = dgvKetQua.RowCount;
            lblTongSo.Text = "Tổng Số: " + dem.ToString();
        }

        private void dgvKetQua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            cbbMaHK.Text = dgvKetQua.Rows[row].Cells[8].Value.ToString();
            cbbMaSV.Text = dgvKetQua.Rows[row].Cells[0].Value.ToString();
            cbbMaMH.Text = dgvKetQua.Rows[row].Cells[1].Value.ToString();
            cbbMaGV.Text = dgvKetQua.Rows[row].Cells[7].Value.ToString();
            txtDiemCC.Text = dgvKetQua.Rows[row].Cells[2].Value.ToString();
            txtDiemKT.Text = dgvKetQua.Rows[row].Cells[3].Value.ToString();
            txtDiemGK.Text = dgvKetQua.Rows[row].Cells[4].Value.ToString();
            txtDiemThi.Text = dgvKetQua.Rows[row].Cells[5].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLySinhVien_BLL.Diem.Nhap_Diem(cbbMaSV.SelectedValue.ToString(), cbbMaMH.SelectedValue.ToString(), float.Parse(txtDiemCC.Text), float.Parse(txtDiemKT.Text), float.Parse(txtDiemGK.Text), float.Parse(txtDiemThi.Text), cbbMaGV.SelectedValue.ToString(), cbbMaHK.SelectedValue.ToString());
                dgvKetQua.DataSource = QuanLySinhVien_DAL.Data.DS_DIEM();
                dem = dgvKetQua.RowCount;
                lblTongSo.Text = "Tổng Số: " + dem.ToString();
            }
            catch
            {
                dgvKetQua.DataSource = QuanLySinhVien_DAL.Data.DS_DIEM();
            }
        }

        
    }
}
