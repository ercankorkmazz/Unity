#pragma strict
var levelSelect : GameObject;
var loginPage : GameObject;
var gamesettings : GameObject;
var gamequit : GameObject;
var gamereset : GameObject;

function Update()
{
	Cursor.visible = true;
}

function LevelSelect()
{
    if(gamesettings.active || gamequit.active || loginPage.active)
    {
        gamesettings.SetActive(false);
        loginPage.SetActive(false);
        gamequit.SetActive(false);
        levelSelect.SetActive(true);
        gamereset.SetActive(false);
    }
    else if(levelSelect.active)
    {
        levelSelect.SetActive(false);
    }
    else if(!levelSelect.active)
    { 
        levelSelect.SetActive(true);
    }
}


function LoginPage()
{
    if(gamesettings.active || gamequit.active || levelSelect.active)
    {
        gamesettings.SetActive(false);
        loginPage.SetActive(true);
        gamequit.SetActive(false);
        levelSelect.SetActive(false);
        gamereset.SetActive(false);
    }
    else if(loginPage.active)
    {
        loginPage.SetActive(false);
    }
    else if(!loginPage.active)
    { 
        loginPage.SetActive(true);
    }
}

 function GameSettings()
 {
     if(levelSelect.active || gamequit.active || loginPage.active)
 	{
        levelSelect.SetActive(false);
        loginPage.SetActive(false);
 		gamequit.SetActive(false);
 		gamesettings.SetActive(true);
 		gamereset.SetActive(false);
 	}
 	else if(gamesettings.active)
 	{
 		gamesettings.SetActive(false);
	}
 	else if(!gamesettings.active)
 	{
 		gamesettings.SetActive(true);
	}
 }

 function GameQuit()
 {
     if(levelSelect.active || gamesettings.active || loginPage.active)
 	{
        gamesettings.SetActive(false);
        loginPage.SetActive(false);
 		levelSelect.SetActive(false);
 		gamequit.SetActive(true);
 		gamereset.SetActive(false);
 	}
 	else if(gamequit.active)
 	{
 		gamequit.SetActive(false);
 	}
 	else if(!gamequit.active)
 	{
 		gamequit.SetActive(true);
 	}
 }

 function reset()
 {
 	if(gamereset.active)
 		gamereset.SetActive(false);
 	else if (!gamereset.active)
 		gamereset.SetActive(true);
 }

 function quit()
 {
 	Application.Quit();
 }

 function LoadScene (level1 : String)
     {
         Application.LoadLevel (level1);
         Cursor.visible = false;
     }

