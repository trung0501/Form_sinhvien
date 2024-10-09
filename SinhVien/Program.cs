using System;
using System.Collections.Generic;

class SinhVien
{
    public string MaSV { get; set; }
    public string HoTen { get; set; }
    public string Lop { get; set; }
    public DateTime NgaySinh { get; set; }
    public double DiemToan { get; set; }
    public double DiemVan { get; set; }
    public double DiemTrungBinh { get; set; }

    public SinhVien(string maSV, string hoTen, string lop, DateTime ngaySinh, double diemToan, double diemVan)
    {
        MaSV = maSV;
        HoTen = hoTen;
        Lop = lop;
        NgaySinh = ngaySinh;
        DiemToan = diemToan;
        DiemVan = diemVan;
        DiemTrungBinh = (diemToan + diemVan) / 2;
    }

    public void InThongTin()
    {
        Console.WriteLine("Ma sinh vien: " + MaSV);
        Console.WriteLine("Ho ten: " + HoTen);
        Console.WriteLine("Lop: " + Lop);
        Console.WriteLine("Ngay sinh: " + NgaySinh.ToString("dd/MM/yyyy"));
        Console.WriteLine("Điem toan: " + DiemToan);
        Console.WriteLine("Điem van: " + DiemVan);
        Console.WriteLine("Điem trung binh: " + DiemTrungBinh);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Tạo danh sách sinh viên
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        // Thêm sinh viên vào danh sách
        danhSachSinhVien.Add(new SinhVien("SV001", "Nguyen Van A", "12A1", new DateTime(2000, 1, 1), 8.5, 7.5));
        danhSachSinhVien.Add(new SinhVien("SV002", "Tran Thi B", "12A1", new DateTime(2000, 2, 2), 7.0, 9.0));
        danhSachSinhVien.Add(new SinhVien("SV003", "Le Van C", "12A2", new DateTime(2000, 3, 3), 9.0, 8.0));

        // In danh sách sinh viên
        Console.WriteLine("Danh sach sinh viên:");
        foreach (SinhVien sv in danhSachSinhVien)
        {
            sv.InThongTin();
        }

        // Sắp xếp danh sách theo mã sinh viên và in ra màn hình
        Console.WriteLine("Danh sach sinh viên sau khi sap xep theo ma sinh viên:");
        danhSachSinhVien.Sort((sv1, sv2) => sv1.MaSV.CompareTo(sv2.MaSV));
        foreach (SinhVien sv in danhSachSinhVien)
        {
            sv.InThongTin();
        }

        // Tìm kiếm sinh viên theo mã nhập từ bàn phím
        Console.Write("Nhap ma sinh vien can tim: ");
        string maSVTimKiem = Console.ReadLine();
        SinhVien sinhVienTimKiem = danhSachSinhVien.Find(sv => sv.MaSV == maSVTimKiem);
        if (sinhVienTimKiem != null)
        {
            Console.WriteLine("Thong tin sinh vien đuoc tim thay:");
            sinhVienTimKiem.InThongTin();
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien co ma {0}.", maSVTimKiem);
        }

        Console.ReadLine();

        // Thêm 1 sinh viên vào vị trí k (k nguyên dương, được nhập từ bàn phím)
        Console.Write("Nhập vị trí k: ");
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhap thông tin sinh viên moi:");
        Console.Write("Ma sinh viên: ");
        string maSV = Console.ReadLine();
        Console.Write("Ho tên: ");
        string hoTen = Console.ReadLine();
        Console.Write("Lop: ");
        string lop = Console.ReadLine();
        Console.Write("Ngay sinh (dd/MM/yyyy): ");
        DateTime ngaySinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Điểm toán: ");
        double diemToan = double.Parse(Console.ReadLine());
        Console.Write("Điểm văn: ");
        double diemVan = double.Parse(Console.ReadLine());

        SinhVien sinhVienMoi = new SinhVien(maSV, hoTen, lop, ngaySinh, diemToan, diemVan);
        danhSachSinhVien.Insert(k - 1, sinhVienMoi);

        // Sửa thông tin điểm toán của sinh viên có mã nhập từ bàn phím.
        Console.Write("Nhập mã sinh viên cần sửa điểm toán: ");
        string maSVSuaDiem = Console.ReadLine();

        SinhVien sinhVienCanSua = danhSachSinhVien.Find(sv => sv.MaSV == maSVSuaDiem);
        if (sinhVienCanSua != null)
        {
            Console.Write("Nhập điểm toán mới: ");
            double diemToanMoi = double.Parse(Console.ReadLine());

            sinhVienCanSua.DiemToan = diemToanMoi;
            sinhVienCanSua.DiemTrungBinh = (sinhVienCanSua.DiemToan + sinhVienCanSua.DiemVan) / 2;

            Console.WriteLine("Đã cập nhật điểm toán của sinh viên {0}.", maSVSuaDiem);
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có mã {0}.", maSVSuaDiem);
        }

        // Xóa sinh viên có mã nhập từ bàn phím.
        Console.Write("Nhập mã sinh viên cần xóa: ");
        string maSVXoa = Console.ReadLine();

        SinhVien sinhVienCanXoa = danhSachSinhVien.Find(sv => sv.MaSV == maSVXoa);
        if (sinhVienCanXoa != null)
        {
            danhSachSinhVien.Remove(sinhVienCanXoa);
            Console.WriteLine("Đã xóa sinh viên có mã {0}.", maSVXoa);
        }
        else
        {
            Console.WriteLine("Không tìm thấy sinh viên có mã {0}.", maSVXoa);
        }
    }
}
