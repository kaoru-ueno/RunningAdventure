using UnityEngine;
using System.Collections;

public class RankingScene : MonoBehaviour {
	private LeaderBoard lBoard;
	public GameObject[] top = new GameObject[5];
	public GameObject[] nei = new GameObject[5];
	public static string _uuid;
	public static string _name;
	private NCMB.HighScore currentHighScore;
	
	bool isScoreFetched;
	bool isRankFetched;
	bool isLeaderBoardFetched;
	
	public GameObject myName;
	public GameObject myScore;
	public GameObject myRank;

	// ボタンが押されると対応する変数がtrueになる
	private bool backButton;
	private bool editButton;

	private int ButtonWidth = 300;
	private int ButtonHeight = 70;

	// Use this for initialization
	void Start () {
		lBoard = new LeaderBoard();
		
		// テキストを表示するゲームオブジェクトを取得
		for( int i = 0; i < 5; ++i ) {
			top[i] = GameObject.Find ("Top" + i);
			nei[i] = GameObject.Find ("Neighbor" + i);
		}
		
		//マイスコアを表示するゲームオブジェクトの取得
		myName = GameObject.Find ("data_name");
		myScore = GameObject.Find ("data_score");
		myRank = GameObject.Find ("data_rank");
		
		// フラグ初期化
		isScoreFetched = false;
		isRankFetched  = false;
		isLeaderBoardFetched = false;
		
		//uuid
		_uuid=PlayerPrefs.GetString("Uuid", "__UNDEFINED__");
		_name=PlayerPrefs.GetString("Name", "__UNDEFINED__");
		System.Guid guid=System.Guid.NewGuid();
		if (_uuid == "__UNDEFINED__") _uuid = guid.ToString();
		if (_name == "__UNDEFINED__") _name = _uuid;
		PlayerPrefs.SetString("Uuid",_uuid);
		PlayerPrefs.SetString("Name",_name);
		PlayerPrefs.Save();
		
		// 現在のハイスコアを取得
		//string name = FindObjectOfType<UserAuth>().currentPlayer();
		currentHighScore = new NCMB.HighScore( -1, _name, _uuid );
		currentHighScore.fetch();	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateRank ();
	}

	void UpdateRank()
	{
		// 現在のハイスコアの取得が完了したら1度だけ実行
		if( currentHighScore.score != -1 && !isScoreFetched ){	
			lBoard.fetchRank( currentHighScore.score );
			isScoreFetched = true;
		}
		
		// 現在の順位の取得が完了したら1度だけ実行
		if( lBoard.currentRank != 0 && !isRankFetched ){
			lBoard.fetchTopRankers();
			lBoard.fetchNeighbors();
			isRankFetched = true;
		}
		
		// ランキングの取得が完了したら1度だけ実行
		if( lBoard.topRankers != null && lBoard.neighbors != null && !isLeaderBoardFetched){	
			// 自分が1位のときと2位のときだけ順位表示を調整
			int offset = 2;
			if(lBoard.currentRank == 1) offset = 0;
			if(lBoard.currentRank == 2) offset = 1;
			
			// 取得したトップ5ランキングを表示
			for( int i = 0; i < lBoard.topRankers.Count; ++i) {
				top[i].guiText.text = i+1 + ". " + lBoard.topRankers[i].print();
			}
			
			// 取得したライバルランキングを表示
			/*
			 for( int i = 0; i < lBoard.neighbors.Count; ++i) {
				nei[i].guiText.text = lBoard.currentRank - offset + i + ". " + lBoard.neighbors[i].print();
			}
			*/

			isLeaderBoardFetched = true;
			Debug.Log ("MyRank_is_"+lBoard.currentRank+",MyName_is_"+_name+",MyHighScore_is_"+currentHighScore.score);
			myName.guiText.text = _name;
			myRank.guiText.text = lBoard.currentRank.ToString();
			myScore.guiText.text = currentHighScore.score.ToString();
		}
		
	}

	void OnGUI () {
		//drawMenu();
		// 戻るボタンが押されたら
		if( backButton )	Application.LoadLevel("Start");

		// ボタンを表示する
		//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight), "ゲームスタート");
		//GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+100, ButtonWidth, ButtonHeight), "ランキング");
		/*if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+20, ButtonWidth, ButtonHeight), "ゲームスタート")){
			print ("スタートをクリックしました");
			Application.LoadLevel ("Test");
		}*/

		if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+100, ButtonWidth, ButtonHeight), "Back")){
			print ("スタート画面に戻りまーす");
			Application.LoadLevel ("Start");
		}

	}

	private void drawMenu() {
		/*int boxW = 400, boxH = 100;
		GUI.Box (new Rect (Screen.width*1/2-boxW, Screen.height*1/2-boxH, boxW, boxH),"RANKING DATA");
		*/
		// ボタンの設置
		int btnW = 170, btnH = 30;
		GUI.skin.button.fontSize = 20;
		backButton = GUI.Button( new Rect(Screen.width*1/2 - btnW, Screen.height*7/8 - btnH*1/2, btnW, btnH), "Back" );
		//editButton = GUI.Button( new Rect(Screen.width*1/2, Screen.height*7/8 - btnH*1/2, btnW, btnH), "EDIT NAME" );
	}
}
