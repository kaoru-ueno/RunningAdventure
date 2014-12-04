using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class StartScene : MonoBehaviour {
	private NCMB.HighScore currentHighScore;
	public static int _score;
	public static string _uuid;
	public static string _name;
	
	private int ButtonWidth = 280;
	private int ButtonHeight = 70;
	private int BgPanelWidth = 552;
	private int BgPanelHeight = 316;
	private int TextFieldWidth = 320;
	private int TextFieldHeight = 50;
	
	private string UserName = "";
	private int maxLength = 20;
	
	public GUIStyle startButtonStyle;
	public GUIStyle inputStyle;
	public GUIStyle rankingButtonStyle;
	public GUIStyle kanryoButtonStyle;
	
	public Texture2D bgPanel;
	
	//private bool is_firstPlay = true;
	private bool is_firstPlay;
	
	// Use this for initialization
	void Start () {
		gameObject.renderer.enabled = false;
		//GameObject.Find("UserName").renderer.enabled = false;
		_score = 0;
		
		if (!PlayerPrefs.HasKey ("Init")) {
			Debug.Log ("初回です");
			is_firstPlay = true;
			PlayerPrefs.SetInt("Init", 1); 
			
		} else {
			is_firstPlay = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
		//デバッグ用　Initの初期化
		if(GUI.Button(new Rect(100,100,80,20), "初期化")) {
			//Application.LoadLevel(1);
			PlayerPrefs.DeleteKey ("Init");
			PlayerPrefs.DeleteKey ("Name");
			//PlayerPrefs.DeleteKey ("Uuid");
		}
		
		
		if (is_firstPlay) {
			//初回起動時
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
					//print ("名前は " + UserName + "です。");
					
					//サーバーにデータを保存
					//UUIDの生成
					System.Guid guid=System.Guid.NewGuid();
					_uuid = guid.ToString();
					_name = UserName;

					currentHighScore = new NCMB.HighScore(_score,_name,_uuid);
					currentHighScore.save();

					//サーバー問い合わせ用にローカル保存
					PlayerPrefs.SetString("Uuid",_uuid);
					PlayerPrefs.SetString("Name",_name);
					
					Application.LoadLevel ("Start");
					//is_firstPlay = false;
				}else{
					print ("名前を入力してください。");
				}
			}
			GUI.EndGroup ();
		}else{
			//起動二回目以降
			// タイトルを表示する
			gameObject.renderer.enabled = true;
			
			// ボタンを表示する
			if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight),"", startButtonStyle)){
				print ("スタートをクリックしました");
				Application.LoadLevel ("Game");
				UnityChan2DController.gameflg = true;

			}
			if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+120, ButtonWidth, ButtonHeight),"", rankingButtonStyle)){
				print ("ランキングをクリックしました");
				Application.LoadLevel ("Ranking");
				UnityChan2DController.gameflg = true;

			}
		}
	}
}
