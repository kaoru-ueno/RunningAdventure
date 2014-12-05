using UnityEngine;

public class EndScore : MonoBehaviour
{
	// スコアを表示するGUIText
	public GUIText endHighScoreGUIText;
	public GUIText endScoreGUIText;
	public GUIText kmGUIText;
	public GUIText clistalScoreGUIText;
	private GameObject main_camera = null;
	private float dist = 0;
	private float total = 0;



	void Start ()
	{
		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject.Find("Km").guiText.text = "";
	}
	
	void Update ()
	{
		if (UnityChan2DController.gameflg == false)
		{
			Vector3 camera_position = this.main_camera.transform.position;
			dist = camera_position.x;
			total = dist + Score.score;

			endHighScoreGUIText.text = Score.highScore.ToString ("0");
			endScoreGUIText.text = total.ToString ("0");
			clistalScoreGUIText.text = Score.score.ToString ("獲得したクリスタルは" + ("0") + "点です");
			kmGUIText.text = camera_position.x.ToString ("あなたの走行距離は" + ("0") + "mです");


		}
	}
}