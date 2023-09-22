#pragma strict

import System.IO;
import System.Runtime.Serialization;
import System.Runtime.Serialization.Formatters.Binary;

var enbuton : UI.Button;
var trbuton : UI.Button;

var play : UI.Button;
var lvlselect : UI.Text;

var setting : UI.Button;
var setText : UI.Text;
var langText : UI.Text;
var close : UI.Button;

var quit : UI.Button;
var quitText : UI.Text;
var quitAns : UI.Text;
var yes : UI.Button;
var	no : UI.Button;


function Update() 
{
	if(play.GetComponentInChildren(UI.Text).text == "PLAY")
	{
		enbuton.interactable = false;
	}
	else if(play.GetComponentInChildren(UI.Text).text == "OYNA")
	{
		trbuton.interactable = false;
	}
}

function en() 
{
	enbuton.interactable = false;
	trbuton.interactable = true;
	play.GetComponentInChildren(UI.Text).text = "PLAY";
	lvlselect.GetComponentInChildren(UI.Text).text = "LEVEL SELECT";

	setting.GetComponentInChildren(UI.Text).text = "SETTINGS";
	setText.GetComponentInChildren(UI.Text).text = "SETTINGS";
	langText.GetComponentInChildren(UI.Text).text = "LANGUAGE";
	close.GetComponentInChildren(UI.Text).text = "CLOSE";

	quit.GetComponentInChildren(UI.Text).text = "QUIT";
	quitText.GetComponentInChildren(UI.Text).text = "QUIT";
	quitAns.GetComponentInChildren(UI.Text).text = "ARE YOU SURE YOU WANT QUIT?";
	yes.GetComponentInChildren(UI.Text).text = "YES";
	no.GetComponentInChildren(UI.Text).text = "NO";
}

function tr() 
{
	enbuton.interactable = true;
	trbuton.interactable = false;
	play.GetComponentInChildren(UI.Text).text = "OYNA";
	lvlselect.GetComponentInChildren(UI.Text).text = "SEVIYE SEÇ";

	setting.GetComponentInChildren(UI.Text).text = "AYARLAR";
	setText.GetComponentInChildren(UI.Text).text = "AYARLAR";
	langText.GetComponentInChildren(UI.Text).text = "DIL";
	close.GetComponentInChildren(UI.Text).text = "KAPAT";

	quit.GetComponentInChildren(UI.Text).text = "ÇIKIS";
	quitText.GetComponentInChildren(UI.Text).text = "ÇIKIS";
	quitAns.GetComponentInChildren(UI.Text).text = "ÇIKMAK ISTEDIGINE EMIN MISIN?";
	yes.GetComponentInChildren(UI.Text).text = "EVET";
	no.GetComponentInChildren(UI.Text).text = "HAYIR";
}
