using UnityEngine;
using NCMB;

public class Score : MonoBehaviour
{
	// スコアを表示するGUIText
	public GUIText scoreGUIText;
	
	// ハイスコアを表示するGUIText
	public GUIText highScoreGUIText;
	
	// スコア
	public static int score;
	
	// ハイスコア
	public static int highScore;

	public static int bonusgauge = 0;

	//サーバーに保存時に必要
	public string _name;
	public string _uuid;
	private NCMB.HighScore currentHighScore;

	
	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";
	
	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		// スコアがハイスコアより大きければ
		if (highScore < (int)EndScore.total) {
			highScore = (int)EndScore.total;
		}
		
		// スコア・ハイスコアを表示する
		//scoreGUIText.text = "Score:" + score.ToString ();
		if(UnityChan2DController.gameflg)
		{
			scoreGUIText.text = score.ToString ();
		}

		highScoreGUIText.text = "HighScore:" + highScore.ToString ();

		//if(UnityChan2DController.gameflg == false)
		//{
		//	Save ();
		//}
	}
	
	// ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		// スコアを0に戻す
		score = 0;
		
		// ハイスコアを取得する。保存されてなければ0を取得する。
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}
	
	// ポイントの追加
	public void AddPoint (int point)
	{
//				switch (score) {
//				case coin:

//		if (other.tag == coin) {
						score = score + point;
						//Debug.Log("score"+score);

					//通常ステージ
					if(UnityChan2DController.bonusflg == false)
						{
							//ボーナスゲージを溜める
							bonusgauge = bonusgauge + point;
							//Debug.Log("bonusgauge"+bonusgauge);
						}
						
//						break;
//				}
//		Debug.Log ("coin" + coin);
//		 if (other.tag = coin) {
//				case scoin:
//					score = score + ;
//						break;
//				}
				}
/*	public void AddPoint (int scoin)
	{
		score = score + scoin;
		//		Debug.Log ("coin" + coin);
		//		score = score + coin;
	}
*/
		
	// ハイスコアの保存
	public void Save ()
	{
		Debug.Log("Score.Save() called!!!!");

		// ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		//サーバーにハイスコアを保存する
		_name = PlayerPrefs.GetString ("Name");
		_uuid = PlayerPrefs.GetString ("Uuid");
		currentHighScore = new NCMB.HighScore( highScore, _name, _uuid );
		currentHighScore.updateScore();	//_uuidの二重登録を防ぐ
		
		// ゲーム開始前の状態に戻す
		Initialize ();
	}
}