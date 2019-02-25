using System;
public struct Mahasiswa
{
    public string nim, nama, kota;
    public DateTime lahir;
    public double getUsia()
    {
        double u;
        u = (DateTime.Now - lahir).Days / 365.25;
        return u;
    }
}