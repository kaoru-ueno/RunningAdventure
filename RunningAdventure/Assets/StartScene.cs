using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	private int ButtonWidth = 300;
	private int ButtonHeight = 70;

	public GUIStyle startButtonStyle;
	public GUIStyle rankingButtonStyle;

	private bool is_firstPlay = true;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (is_firstPlay) {
			Rect rect1 = new Rect(10, 10, 400, 30);
			GUI.TextField(rect1, "Stand by Ready!!");


		}else{
			// タイトルを表示する
			gameObject.renderer.enabled = true;

			// ボタンを表示する
			//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight), "ゲームスタート");
			//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+100, ButtonWidth, ButtonHeight), "ランキング");
			if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight),"", startButtonStyle)){
				print ("スタートをクリックしました");
				Application.LoadLevel ("Test");
			}
			if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+120, ButtonWidth, ButtonHeight),"", rankingButtonStyle)){
				print ("ランキングをクリックしました");
				Application.LoadLevel ("Ranking");
			}
		}
	}
}
