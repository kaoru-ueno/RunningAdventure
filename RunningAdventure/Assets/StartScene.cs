﻿using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	private int ButtonWidth = 300;
	private int ButtonHeight = 70;

	private int maxLength = 20;
		
	public GUIStyle startButtonStyle;
	public GUIStyle inputStyle;
	public GUIStyle rankingButtonStyle;
	public GUIStyle kanryoButtonStyle;

	public Texture2D UserName;

	private bool is_firstPlay = true;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		GameObject.Find("UserName").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (is_firstPlay) {
			// グループの背景にTexture2Dのテクスチャを指定.
			GUIStyle style = new GUIStyle();
			style.normal.background = UserName;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 552 / 2, Screen.height / 2 - 316 / 2, 552, 316), style);

			// 
			//GameObject.Find("UserName").renderer.enabled = true;

			Rect rect1 = new Rect(10, 10, 300, 30);
			GUI.TextField(rect1, "Stand by Ready!!", maxLength, inputStyle);

			if (GUI.Button(new Rect(552 / 2 - ButtonWidth / 2, (316 / 2 - ButtonHeight / 2)+90, ButtonWidth, ButtonHeight),"", kanryoButtonStyle)){
				print ("入力完了！をクリックしました");
				//Application.LoadLevel ("Test");
			}

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
