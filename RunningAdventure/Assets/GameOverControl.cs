using UnityEngine;
using System.Collections;

public class GameOverControl : MonoBehaviour {

	void Start () 
	{
		GameObject.Find("EndHighText GUI").guiText.text = "";
		GameObject.Find("EndHighText GUI2").guiText.text = "";
		GameObject.Find("EndHighScore GUI").guiText.text = "";
		GameObject.Find("EndText GUI").guiText.text = "";
		GameObject.Find("EndText GUI2").guiText.text = "";
		GameObject.Find("EndScore GUI").guiText.text = "";
		GameObject.Find("Km").guiText.text = "";
		GameObject.Find("ClistarScore").guiText.text = "";
		GameObject.Find("Retry").guiText.text = "";

	}
	
	void Update () {
	
	}
}
