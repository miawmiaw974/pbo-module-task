using System;
using System.Collections.Generic;

// Kelas Karyawan
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public virtual void Kerja()
    {
        Console.WriteLine(Nama + " sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine("Nama: " + Nama + ", Gaji: " + Gaji);
    }
}

// Kelas Tetap
class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("Nama: " + Nama + ", Gaji: " + Gaji + ", Tunjangan: " + Tunjangan);
    }
}

// Manager
class Manager : Tetap
{
    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai Manager.");
    }

    public void Memimpin()
    {
        Console.WriteLine(Nama + " sedang memimpin tim.");
    }
}

// Staff
class Staff : Tetap
{
    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai Staff.");
    }

    public void KerjakanTugas()
    {
        Console.WriteLine(Nama + " sedang mengerjakan tugas.");
    }
}

// Kelas Kontrak
class Kontrak : Karyawan
{
    public int Durasi { get; set; }

    public void CekKontrak()
    {
        Console.WriteLine(Nama + " kontrak selama " + Durasi + " bulan.");
    }
}

// Magang
class Magang : Kontrak
{
    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai Magang.");
    }

    public void Belajar()
    {
        Console.WriteLine(Nama + " sedang belajar.");
    }
}

// Freelancer
class Freelancer : Kontrak
{
    public override void Kerja()
    {
        Console.WriteLine(Nama + " bekerja sebagai Freelancer.");
    }

    public void AmbilProyek()
    {
        Console.WriteLine(Nama + " sedang mengambil proyek.");
    }
}

// Perusahaan
class Perusahaan
{
    private List<Karyawan> daftar = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftar.Add(karyawan);
    }

    public void DaftarKaryawan()
    {
        foreach (var k in daftar)
        {
            k.InfoKaryawan();
            k.Kerja();
        }
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        Perusahaan p = new Perusahaan();

        Manager m = new Manager { Nama = "Alok", Gaji = 10000000, Tunjangan = 2000000 };
        Staff s = new Staff { Nama = "Aldok", Gaji = 5000000, Tunjangan = 1000000 };
        Magang mg = new Magang { Nama = "Lily", Gaji = 1000000, Durasi = 6 };
        Freelancer f = new Freelancer { Nama = "Rian", Gaji = 3000000, Durasi = 3 };

        p.TambahKaryawan(m);
        p.TambahKaryawan(s);
        p.TambahKaryawan(mg);
        p.TambahKaryawan(f);

        p.DaftarKaryawan();

        Console.WriteLine("\n--- Polymorphism ---");
        Karyawan k = s;
        k.Kerja();

        Console.WriteLine("\n--- Method Khusus ---");
        m.Memimpin();
        s.KerjakanTugas();
        mg.Belajar();
        f.AmbilProyek();
    }
}
