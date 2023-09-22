#pragma strict

var pause : GameObject;
var gamesettings : GameObject;
var mainmenu : GameObject;
var GirisPaneli : GameObject;
var KaybettinPaneli : GameObject;
var KazandinPaneli : GameObject;



var seviyeYazi : GameObject;
var yaziSure : float ;

function Update()
{
	Invoke("yazi",yaziSure);
	
	if(Input.GetKeyDown("escape"))
	{
	 	pausee();
	}
}

function restart(scene : int)
{
	Application.LoadLevel(scene);
	Time.timeScale = 1.0f;
	Cursor.visible = true;
}

function setting(deger : boolean)
{
	gamesettings.SetActive(deger);
}

function mainMenu(deger : boolean)
{
    mainmenu.SetActive(deger);
}
function zamaniDurdur()
{
    Time.timeScale = 0.0f;
}
function pausee() 
{
    KaybettinPaneli.SetActive(false);
    KazandinPaneli.SetActive(false);
    GirisPaneli.SetActive(false);
    yazi();

    if(pause.active)
    {
            pause.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.visible = true;
            gamesettings.SetActive(false);
            mainmenu.SetActive(false);
    }
    else if(!pause.active)
    {
            pause.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
    }
}
function yazi()
{
    seviyeYazi.SetActive(false);
}
   