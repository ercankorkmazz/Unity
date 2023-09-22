using UnityEngine;
using System.Collections;
using Mono.Data.SqliteClient;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UnityEngine.UI;

public struct ProgramInformations
{
    public string programName;
    public string instructorName;
    public float setNumber;
    public float restTime;
}

public class ServerDatabase : MonoBehaviour
{

    public static ServerDatabase Instance = null;

    public Text errorText;

    private SqlConnection connection;
    private SqlConnectionStringBuilder connStringBuilder;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        connStringBuilder = new SqlConnectionStringBuilder();
        connStringBuilder.DataSource = "SQLEXPRESS";
        connStringBuilder.InitialCatalog = "fizikTedaviOyunu";
        connStringBuilder.UserID = "fizikTedevi";
        connStringBuilder.Password = "123456";
        connStringBuilder.ConnectTimeout = 5;

        connection = new SqlConnection(connStringBuilder.ToString());
        //connection = new SqlConnection("Data Source=PC1;Initial Catalog=fizikTedaviOyunu;User ID=fizikTedavi;Password=106042016Bote;Connect Timeout=5");
        if (errorText != null)
            errorText.text = "";
    }

    public void ExecuteQuery(string query)
    {
        connection.Open();
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        command.Dispose();
        command = null;
        connection.Close();
    }

    public bool IsConnectionOpened()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return false;
        return true;        
    }

    public User girisPaneliKullaniciKontrolu(string gelenKadi, string gelenSifre)
    {
        User user = new User();

        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT * FROM kullanicilar WHERE kadi = '" + gelenKadi + "' and sifre = '" + gelenSifre + "'";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            user.id = reader.GetInt32(0);
            user.hastaID = reader.GetInt32(1);
            user.adSoyad = reader.GetString(2);
            user.kadi = reader.GetString(3);
            user.sifre = reader.GetString(4);
            user.KTuru = reader.GetByte(5);
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return user;
    }
    public hastalar hastaSorgula(int gelenHastaID)
    {
        hastalar hasta = new hastalar();

        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT * FROM hastalar WHERE id = '" + gelenHastaID.ToString() + "'";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            hasta.id = reader.GetInt32(0);
            hasta.TC = reader.GetString(1);
            hasta.adSoyad = reader.GetString(2);
            hasta.yas = reader.GetInt32(3);
            hasta.hastaninDurumu = reader.GetString(4);
            hasta.asamaSayisi = reader.GetInt32(5);
            hasta.asamaKontrolu = reader.GetByte(6);
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return hasta;
    }
    public int asamayaGoreHarekSayisiSorgula(string gelenHastaID, string asamaNO)
    {
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT id FROM egzersizProgramlari WHERE hastaID = '" + gelenHastaID + "' and asamaNO = '" + asamaNO + "'";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        int hareketSay = 0;
        while (reader.Read())
            hareketSay++;

        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return hareketSay;
    }
    public int asamayaGoreHareketTekrariSayisiSorgula(string gelenHastaID, string asamaNO)
    {
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT hareketTekrari FROM egzersizProgramlari WHERE hastaID = '" + gelenHastaID + "' and asamaNO = '" + asamaNO + "'";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        int hareketTekrariSay = 0;
        while (reader.Read())
            hareketTekrariSay += reader.GetInt32(0);

        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return hareketTekrariSay;
    }
    public string[,] asamayaGoreHareketSorgula(string gelenHastaID, string asamaNO)
    {
        int satirSayisi = asamayaGoreHarekSayisiSorgula(gelenHastaID, asamaNO);

        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT * FROM egzersizProgramlari WHERE hastaID = '" + gelenHastaID + "' and asamaNO = '" + asamaNO + "' order by id";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();
        
        int sayac = 0;
        
        string[,] hareketListesi = new string[satirSayisi, 7];

        while (reader.Read())
        {
            hareketListesi[sayac,0] = reader.GetInt32(0).ToString();
            hareketListesi[sayac,1] = reader.GetInt32(1).ToString();
            hareketListesi[sayac,2] = reader.GetByte(2).ToString();
            hareketListesi[sayac,3] = reader.GetInt32(3).ToString();
            hareketListesi[sayac,4] = reader.GetInt32(4).ToString();
            hareketListesi[sayac,5] = reader.GetInt32(5).ToString();
            hareketListesi[sayac,6] = reader.GetString(6).ToString();

            sayac++;
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return hareketListesi;
    }
    public void asamaKontroluSifirla(int gelenHastaID)
    {
        string commandString = "UPDATE hastalar SET asamaKontrolu='0' where id='" + gelenHastaID + "'";
        ExecuteQuery(commandString);
    }
    public string hareketAdiSordula(string hareketID)
    {
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            print(ex);
            errorText.text = "VERITABANI BAGLANTI HATASI";
            throw;
        }

        string commandString = "SELECT hareketADI FROM hareketler WHERE hareketID = '" + hareketID + "'";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        string hareketAdi = "";
        while (reader.Read())
        {
            hareketAdi = reader.GetString(0);
        }

        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return hareketAdi;
    }
    public void skoruKaydet(int hastaID, int asamaNO, string basariDurumu)
    {
        DateTime gelenTarih = DateTime.Today;
        int yil = gelenTarih.Year;
        int ay = gelenTarih.Month;
        int gun = gelenTarih.Day;

        string tarih = gun + "-" + ay + "-" + yil;

        string insertSQLText = "INSERT INTO skorlar (hastaID, asamaNO, basariDurumu, tarih) VALUES ('" + hastaID + "', '" + asamaNO + "', '" + basariDurumu + "', '" + tarih + "')";
        
        ExecuteQuery(insertSQLText);
    }
    /*
    public List<string> GetProgramNames()
    {
        List<string> programs = new List<string>();

        connection.Open();
        string commandString = "SELECT ProgramName FROM ProgramsTable";
        SqlCommand command = new SqlCommand(commandString, connection);
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            programs.Add(reader.GetString(0));
        }
        reader.Close();
        reader = null;
        command.Dispose();
        command = null;
        connection.Close();

        return programs;
    }
    
    public void RemoveFromProgramsInfo(string programName)
    {
        programName = "'" + programName + "'";
        string insertSQLText = "DELETE FROM ProgramsInfo WHERE ProgramName = " + programName;
        ExecuteQuery(insertSQLText);
    }
    
    public void InsertFile(string fileName, string fileExtension, byte[] fileContent)
    {
        connection.Open();

        SqlCommand command = new SqlCommand("SaveDocument", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = fileName;
        command.Parameters.Add("@Extension", SqlDbType.VarChar).Value = fileExtension;
        command.Parameters.Add("@FileContent", SqlDbType.VarBinary).Value = fileContent;
        command.ExecuteNonQuery();

        command.Dispose();
        command = null;
        connection.Close();
    }

    public byte[] GetFile(string fileName)
    {
        connection.Open();

        DataTable dataTable = new DataTable();
        SqlCommand command = new SqlCommand("GetDocument", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = fileName;
        SqlDataReader reader = command.ExecuteReader();
        dataTable.Load(reader);

        string name = dataTable.Rows[0]["Name"].ToString();
        string extension = dataTable.Rows[0]["Extension"].ToString();
        byte[] fileContent = (byte[])dataTable.Rows[0]["FileContent"];

        command.Dispose();
        command = null;
        connection.Close();

        return fileContent;
    }*/
}