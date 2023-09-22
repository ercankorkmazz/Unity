using System.Collections;
using System.Collections.Generic;

public class hareketler
{

    public int id;
    public int hastaID;
    public byte asamaNO;
    public int hareketID;
    public int beklemeSuresi;
    public int hareketTekrari;
    public string aciklamalar;

    public hareketler()
    {
        id = 0;
        hastaID = 0;
        asamaNO = 0;
        hareketID = 0;
        beklemeSuresi = 0;
        hareketTekrari = 0;
        aciklamalar = "";
    }

    public hareketler(int _id, int _hastaID, byte _asamaNO, int _hareketID, int _beklemeSuresi, int _hareketTekrari, string _aciklamalar)
    {
        id = _id;
        hastaID = _hastaID;
        asamaNO = _asamaNO;
        hareketID = _hareketID;
        beklemeSuresi = _beklemeSuresi;
        hareketTekrari = _hareketTekrari;
        aciklamalar = _aciklamalar;
    }
}
