using UnityEngine;
using System.Collections;

public class User
{
    public int id;
    public int hastaID;
    public string adSoyad;
    public string kadi;
    public string sifre;
    public byte KTuru; // 1: Fizyoterapist, 2: Hasta

    public User()
    {
        id = 0;
        hastaID = 0;
        KTuru = 0;
        adSoyad = kadi = sifre = null;
    }
    public User(int _id, int _hastaID, string _adSoyad, string _kadi, string _sifre, byte _KTuru)
    {
        id = _id;
        hastaID = _hastaID;
        adSoyad = _adSoyad;
        kadi = _kadi;
        sifre = _sifre;
        KTuru = _KTuru;
    }
}
