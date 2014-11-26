using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	private int ButtonWidth = 300;
	private int ButtonHeight = 70;
	private int BgPanelWidth = 552;
	private int BgPanelHeight = 316;
	private int TextFieldWidth = 320;
	private int TextFieldHeight = 50;

	private string UserName = "aaa";
	private int maxLength = 20;
		
	public GUIStyle startButtonStyle;
	public GUIStyle inputStyle;
	public GUIStyle rankingButtonStyle;
	public GUIStyle kanryoButtonStyle;

	public Texture2D bgPanel;

	private bool is_firstPlay = true;

	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		//GameObject.Find("UserName").renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if (is_firstPlay) {
			// グループの背景にTexture2Dのテクスチャを指定.
			GUIStyle style = new GUIStyle();
			style.normal.background = bgPanel;
			GUI.BeginGroup(new Rect(Screen.width / 2 - BgPanelWidth / 2, Screen.height / 2 - BgPanelHeight / 2, BgPanelWidth, BgPanelHeight), style);

			// 入力フィールドを作る
			Rect rect1 = new Rect(BgPanelWidth / 2 - TextFieldWidth / 2, (BgPanelHeight / 2 - TextFieldHeight / 2)-30, TextFieldWidth, TextFieldHeight);
			UserName = GUI.TextField(rect1, UserName, maxLength, inputStyle);
			//フォーカスの当て方が分からない！あとフォーカスカーソルの色の変え方も。
			//GUI.SetNextControlName("NameField");
			//GUI.FocusControl("NameField");
			//GUI.FocusWindow(NameField);

			if (GUI.Button(new Rect(BgPanelWidth / 2 - ButtonWidth / 2, (BgPanelHeight / 2 - ButtonHeight / 2)+90, ButtonWidth, ButtonHeight),"", kanryoButtonStyle)){
				if(UserName != ""){
					print ("名前は " + UserName + "です。");
					is_firstPlay = false;
				}else{
					print ("名前を入力してください。");
				}
			}
			GUI.EndGroup ();
		}else{
			// タイトルを表示する
			gameObject.renderer.enabled = true;

			// ボタンを表示する
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
