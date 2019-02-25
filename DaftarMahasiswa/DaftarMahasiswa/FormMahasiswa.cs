using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaftarMahasiswa
{
    public partial class FormMahasiswa : Form
    {
        void modeEdit()
        {
            txtNim.Enabled = true;
            txtNama.Enabled = true;
            txtKota.Enabled = true;
            dtpLahir.Enabled = true;
            txtNim.Focus();
            btnTop.Enabled = false;
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnEnd.Enabled = false;
            btnFind.Enabled = false;
            btnPrint.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnSave.Visible = true;
            btnUndo.Visible = true;
            btnClose.Enabled = false;
        }
        void modeSave()
        {
            txtNim.Enabled = false;
            txtNama.Enabled = false;
            txtKota.Enabled = false;
            dtpLahir.Enabled = false;
            btnTop.Enabled = true;
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            btnEnd.Enabled = true;
            btnFind.Enabled = true;
            btnPrint.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnSave.Visible = false;
            btnUndo.Visible = false;
            btnClose.Enabled = true;
        }

        public FormMahasiswa() //<-- Konstruktor
        {
            InitializeComponent();
            daf = new Tabel(25);
        }
        Tabel daf;
        bool baru;

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult jwb = MessageBox.Show("Yakin dihapus?", 
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (jwb == DialogResult.Yes)
            {
                //Langkah 0 : Hapus elemen
                //Langkah 1 : tampilkan pesan "Sudah dihapus..."
            }
            else
            {
                //Langkah 0 : tampilkan pesan "Tidak jadi dihapus..."
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            baru = true;
            txtNim.Text = "";
            txtNama.Text = "";
            txtKota.Text = "";
            modeEdit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Mahasiswa m;
            m.nim = txtNim.Text;
            m.nama = txtNama.Text;
            m.kota = txtKota.Text;
            m.lahir = dtpLahir.Value;
            txtUsia.Text = m.getUsia().ToString();
            if(baru)
                daf.tambahMhs(m);
            else
                daf.updateMhs(m);

            modeSave();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            baru = false;
            modeEdit();
        }

        private void Tampil()
        {
            Mahasiswa read = daf.getElemen();
            txtNama.Text = read.nama.ToString();
            txtNim.Text = read.nim.ToString();
            txtKota.Text = read.kota.ToString();
            txtUsia.Text = read.getUsia().ToString();
            dtpLahir.Value = read.lahir;
        }


        //NAVIGASI
        private void btnNext_Click(object sender, EventArgs e)
        {
            daf.moveNext();
            Tampil();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            daf.movePrevious();
            Tampil();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            daf.moveFirst();
            Tampil();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            daf.moveLast();
            Tampil();
        }
    }
}
