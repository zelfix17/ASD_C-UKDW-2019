using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaftarMahasiswa
{
    public class Tabel
    {
        private Mahasiswa[] daftar;
        private int cacah; //<-- yang sudah terisi
        private int recPointer;

        public Tabel(int b) //<-- konstruktor
        {
            daftar = new Mahasiswa[b];
            cacah = 0;
        }
  
        public void tambahMhs(Mahasiswa m) //<-- CREATE
        {
            daftar[cacah] = m;
            recPointer = cacah;
            cacah++; //<-- banyaknya yang terisi
        }

        public Mahasiswa getElemen() //<-- READ
        {
            return daftar[recPointer]; //<-- ambil 1 elemen yg sedang ditunjuk
        }

        public void moveFirst()
        {
            recPointer = 0;
        }

        public void movePrevious()
        {
            if (recPointer > 0)
                recPointer--; //<-- maju
            else
                MessageBox.Show("Sudah Paling Awal!");
        }

        public void moveNext()
        {
            if (recPointer < cacah - 1)
                recPointer++;
            else
                MessageBox.Show("Sudah Paling Akhir!");
        }
        public void moveLast()
        {
            recPointer = cacah - 1;
        }

        public void updateMhs(Mahasiswa m) //<-- UPDATE
        {
            daftar[recPointer] = m;
        }

        public void deleteMhs()  //<-- DELETE
        {
            for (int i = recPointer; i < cacah - 1; i++)
                daftar[i] = daftar[i + 1];
            cacah--;
            recPointer = 0;
        }
        
    }
}
