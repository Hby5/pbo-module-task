using System;
using System.Collections.Generic;

public class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        this.Judul = judul;
        this.Tahun = tahun;
    }

    public virtual void Deskripsi()
    {
        Console.WriteLine($"Item: {Judul}, Tahun: {Tahun}");
    }

    public void InfoItem()
    {
        Console.WriteLine($"Judul: {Judul}, Tahun Terbit: {Tahun}");
    }
}

public class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        this.Penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Penulis buku '{Judul}' adalah: {Penulis}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Buku: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }
}

public class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        this.Edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Majalah '{Judul}' edisi ke-{Edisi}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }
}

public class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Sinopsis Novel '{Judul}': Cerita yang menarik dan penuh emosi.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Novel: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }
}

public class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Menampilkan ilustrasi dari komik '{Judul}'.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Komik: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }
}

public class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public void KategoriAnak()
    {
        Console.WriteLine($"Majalah '{Judul}' kategori majalah anak-anak.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Anak: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }
}

public class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public void TopikTeknologi()
    {
        Console.WriteLine($"Majalah '{Judul}' topik teknologi terkini.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Teknologi: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }
}

public class Perpustakaan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
        Console.WriteLine($"Item '{item.Judul}' berhasil ditambahkan ke perpustakaan.");
    }

    public void DaftarItem()
    {
        Console.WriteLine("\nITEM PERPUSTAKAAN");
        if (koleksi.Count == 0)
        {
            Console.WriteLine("Tidak ada item di perpustakaan.");
            return;
        }

        foreach (var item in koleksi)
        {
            item.Deskripsi();
        }
    }
}
class Program
{
    static void Main()
    {
        Perpustakaan perpus = new Perpustakaan();

        Novel novel1 = new Novel("Haslaikning slasher", 2005, "Tuan crab");
        Komik komik1 = new Komik("Invincible", 2018, "Faza");
        MajalahAnak majalahAnak1 = new MajalahAnak("Bobo", 2020, 125);
        MajalahTeknologi majalahTekno1 = new MajalahTeknologi("CHIP", 2023, 45);

        perpus.TambahItem(novel1);
        perpus.TambahItem(komik1);
        perpus.TambahItem(majalahAnak1);
        perpus.TambahItem(majalahTekno1);

        perpus.DaftarItem();

        Console.WriteLine("\nPOLYMORPHISM");
        Item[] items = { novel1, komik1, majalahAnak1, majalahTekno1 };
        foreach (Item item in items)
        {
            item.Deskripsi(); 
        }

        Console.WriteLine("\nMETHOD KHUSUS");

        novel1.CekPenulis();
        novel1.BacaSinopsis();

        komik1.CekPenulis();
        komik1.TampilkanIlustrasi();

        majalahAnak1.InfoEdisi();
        majalahAnak1.KategoriAnak();

        majalahTekno1.InfoEdisi();
        majalahTekno1.TopikTeknologi();

        Console.WriteLine("\nLANJUTAN");

        novel1.InfoItem();
        komik1.InfoItem();
        majalahAnak1.InfoItem();

        Console.WriteLine("\nDemonstrasi casting:");
        Item itemBaru = new Novel("Aku Kamu dan Hujan Hari Rabu", 2002, "Kurniawan");
        if (itemBaru is Novel)
        {
            Novel novelBaru = (Novel)itemBaru;
            novelBaru.BacaSinopsis();
        }

        
    }
}