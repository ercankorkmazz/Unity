using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    GameObject GameControler_Object;
    level mylevel;

    public GameObject levelSelect;
    public GameObject loginPage;
    public GameObject gamesettings;
    public GameObject gamequit;
    public GameObject gamereset;

    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler"); // Sahnedeki nese adı ile o nesneye ekli Class'a ulaşmaya yarar.
        mylevel = GameControler_Object.GetComponent<level>();
    }

    public void LevelSelect()
    {
        if (gamesettings.activeSelf || gamequit.activeSelf || loginPage.activeSelf)
        {
            gamesettings.SetActive(false);
            loginPage.SetActive(false);
            gamequit.SetActive(false);
            levelSelect.SetActive(true);
            gamereset.SetActive(false);
        }
        else if (levelSelect.activeSelf)
        {
            levelSelect.SetActive(false);
        }
        else if (!levelSelect.activeSelf)
        {
            levelSelect.SetActive(true);
        }
    }
    public void LoginPage()
    {
        if (gamesettings.activeSelf || gamequit.activeSelf || levelSelect.activeSelf)
        {
            gamesettings.SetActive(false);
            loginPage.SetActive(true);
            gamequit.SetActive(false);
            levelSelect.SetActive(false);
            gamereset.SetActive(false);
        }
        else if (loginPage.activeSelf)
        {
            loginPage.SetActive(false);
        }
        else if (!loginPage.activeSelf)
        {
            loginPage.SetActive(true);
        }
    }

    public void GameSettings()
    {
        if (levelSelect.activeSelf || gamequit.activeSelf || loginPage.activeSelf)
        {
            levelSelect.SetActive(false);
            loginPage.SetActive(false);
            gamequit.SetActive(false);
            gamesettings.SetActive(true);
            gamereset.SetActive(false);
        }
        else if (gamesettings.activeSelf)
        {
            gamesettings.SetActive(false);
        }
        else if (!gamesettings.activeSelf)
        {
            gamesettings.SetActive(true);
        }
    }

    public void GameQuit()
    {
        if (levelSelect.activeSelf || gamesettings.activeSelf || loginPage.activeSelf)
        {
            gamesettings.SetActive(false);
            loginPage.SetActive(false);
            levelSelect.SetActive(false);
            gamequit.SetActive(true);
            gamereset.SetActive(false);
        }
        else if (gamequit.activeSelf)
        {
            gamequit.SetActive(false);
        }
        else if (!gamequit.activeSelf)
        {
            gamequit.SetActive(true);
        }
    }

    public void reset()
    {
        if (gamereset.activeSelf)
            gamereset.SetActive(false);
        else if (!gamereset.activeSelf)
            gamereset.SetActive(true);
    }

    public void quit()
    {
        gamesettings.SetActive(false);
        loginPage.SetActive(false);
        levelSelect.SetActive(false);
        gamequit.SetActive(false);
        gamereset.SetActive(false);
    }

    public void SeviyeGetir(int sahneID)
    {
        Application.LoadLevel(1);
        mylevel.aktifSahneKaydet(sahneID);
    }
}
