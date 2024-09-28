using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Linq;
using System.Reflection.Metadata;
using System.Data;

namespace DuAn.All_User_Control
{
    public partial class Uc_Invoices : UserControl
    {

        Function fn = new Function();
        String query;
        public Uc_Invoices()
        {
            InitializeComponent();
            LoadData();

        }



        private void Uc_Invoices_Load_1(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";

            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void LoadData()
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";

            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }


        private void btnExport_Click(object sender, EventArgs e)
        {

            ExportToPdf();

        }
        private void ExportToPdf()
        {
            // Tạo một từ điển ánh xạ tên cột cũ sang tên cột mới
            Dictionary<string, string> columnNameMapping = new Dictionary<string, string>
    {
           { "cid", "Ma khach Hang" },
        { "cname", "Ten Khach Hang" },
        { "mobile", "So Dien Thoai" },
        { "nationality", "Quoc Tich" },
        { "gender", "Gioi TInh" },
        { "dob", "Ngay Sinh" },
        { "idproof", "Ma Dinh Danh" },
        { "address", "Dia Chi" },
        { "checkin", "Ngày Dat Phong" },
        { "roomNo", "So Phong" },
        { "roomType", "Loai Phong" },
        { "bed", "Loai Giuong" },
        { "price", "Gia" }
        // Thêm các ánh xạ cột khác ở đây
    };
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";
            DataSet dataSet = fn.getdata(query);
            var dataList = new List<object>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                var khachHang = new
                {
                    MaKhachHang = row["cid"],
                    TenKhachHang = row["cname"],
                    SoDienThoai = row["mobile"],
                    QuocTich = row["nationality"],
                    GioiTinh = row["gender"],
                    NgaySinh = row["dob"],
                    ChungMinhThu = row["idproof"],
                    DiaChi = row["address"],
                    NgayNhanPhong = row["checkin"],
                    SoPhong = row["roomNo"],
                    LoaiPhong = row["roomType"]
                };
                dataList.Add(khachHang);
            }
            // Process or display the dataList as needed

            // Sử dụng dictionary để ánh xạ tên cột cũ sang tên cột mới

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (.pdf)|.pdf";
            saveFileDialog.Title = "Save an Invoice File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A3);
                    PdfWriter.GetInstance(document, stream);
                    document.Open();


                    // Lấy danh sách các cột sẽ được xuất ra PDF
                    var visibleColumns = guna2DataGridView1.Columns.Cast<DataGridViewColumn>()
             .Where(col => columnNameMapping.ContainsKey(col.Name))
             .ToList();

                    PdfPTable pdfTable = new PdfPTable(guna2DataGridView1.Columns.Count);

                    // Add table headers
                    foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                    {
                        string columnName = column.Name;
                        if (columnNameMapping.ContainsKey(columnName))
                        {
                            columnName = columnNameMapping[columnName];
                        }
                        PdfPCell cell = new PdfPCell(new Phrase(columnName, FontFactory.GetFont("Arial Unicode MS", 12, BaseColor.BLACK)));
                        cell.BackgroundColor = BaseColor.WHITE;
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;
                        /* foreach (DataGridViewCell cell in row.Cells)
                         {
                             pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                         }*/

                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string cellValue = cell.Value?.ToString() ?? string.Empty;
                            pdfTable.AddCell(new Phrase(cellValue, FontFactory.GetFont("Arial", 10)));
                        }
                    }
                    document.Add(pdfTable);
                    document.Close();
                }
            }

            MessageBox.Show("in Thành Công!", "xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtname.Text + "%' and chekout = 'YES'";
            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, customer.nationality, customer.gender, customer.dob, customer.idproof, customer.address, customer.checkin, rooms.roomNo, rooms.roomType, rooms.bed, rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtname.Text + "%' and chekout = 'YES'";
            DataSet ds = fn.getdata(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }





}
