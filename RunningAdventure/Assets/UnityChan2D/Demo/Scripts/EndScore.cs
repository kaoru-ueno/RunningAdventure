using UnityEngine;

public class EndScore : MonoBehaviour
{
	// スコアを表示するGUIText
	public GUIText endHighScoreGUIText;
	public GUIText endScoreGUIText;
	public GUIText kmGUIText;
	public GUIText clistalScoreGUIText;
	private GameObject main_camera = null;

	void Start ()
	{
		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject.Find("Km").guiText.text = "";
	}
	
	void Update ()
	{
		if (UnityChan2DController.gameflg == false)
		{
			endHighScoreGUIText.text = Score.highScore.ToString ();
			//endScoreGUIText.text = Score.score.ToString ((””));
			clistalScoreGUIText.text = Score.score.ToString ("獲得したクリスタルは" + ("0") + "点です");
			Vector3 camera_position = this.main_camera.transform.position;
			kmGUIText.text = camera_position.x.ToString ("あなたの走行距離は" + ("0") + "mです");
		}
	}
}