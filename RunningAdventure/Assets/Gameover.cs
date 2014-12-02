using UnityEngine;
using System.Collections;

public class Gameover : MonoBehaviour {

	private int ButtonWidth = 250;
	private int ButtonHeight = 65;
	public GUIStyle retryButtonStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		//drawMenu();
		if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+150, ButtonWidth, ButtonHeight), "", retryButtonStyle)){
			print ("スタート画面に戻りまーす");
			Application.LoadLevel ("Start");
		}
		
	}
}
