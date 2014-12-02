using UnityEngine;

public class EndScore : MonoBehaviour
{
	// スコアを表示するGUIText
	public GUIText endHighScoreGUIText;
	public GUIText endScoreGUIText;
	public GUIText kmGUIText;
	public GUIText clistalScoreGUIText;
	private GameObject main_camera = null;
	private float maxPoint;
	void Start ()
	{
		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject.Find("Km").guiText.text = "";
	}
	void Update ()
	{
		endHighScoreGUIText.text = Score.highScore.ToString ();
		clistalScoreGUIText.text = Score.score.ToString ("獲得したクリスタルは" + ("0") + "点です");
		Vector3	camera_position = this.main_camera.transform.position;
		float m = camera_position.x;
		kmGUIText.text = m.ToString ("あなたの走行距離は" + ("0") + "mです");
		maxPoint = Mathf.RoundToInt(m + Score.score);
		endScoreGUIText.text = maxPoint.ToString ("");
	}
}