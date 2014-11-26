using UnityEngine;
using System.Collections;

public class UseNameInput : MonoBehaviour {
	private int ButtonWidth = 300;
	private int ButtonHeight = 70;
	private int maxLength = 20;
	public GUIStyle inputStyle;
	public Texture2D UserName;
	public GUIStyle kanryoButtonStyle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
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
	}
}
