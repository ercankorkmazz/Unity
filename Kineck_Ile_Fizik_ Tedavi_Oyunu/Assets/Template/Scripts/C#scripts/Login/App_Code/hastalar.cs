using System.Collections;
using System.Collections.Generic;

public class hastalar{

    public int id;
    public string TC;
    public string adSoyad;
    public int yas;
    public string hastaninDurumu;
    public int asamaSayisi;
    public byte asamaKontrolu;

    public hastalar()
    {
        id = 0;
        yas = 0;
        asamaSayisi = 0;
        TC = adSoyad = hastaninDurumu = null;
    }

    public hastalar(int _id, string _TC, string _adSoyad, int _yas, string _hastaninDurumu, int _asamaSayisi,byte _asamaKontrolu)
    {
        id = _id;
        TC = _TC;
        adSoyad = _adSoyad;
        yas = _yas;
        hastaninDurumu = _hastaninDurumu;
        asamaSayisi = _asamaSayisi;
        asamaKontrolu =_asamaKontrolu;
    }
}
