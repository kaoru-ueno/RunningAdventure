using UnityEngine;

public class EndScore : MonoBehaviour
{
	// スコアを表示するGUIText
	public GUIText endHighScoreGUIText;
	public GUIText endScoreGUIText;

	void Start ()
	{

	}
	
	void Update ()
	{

		endHighScoreGUIText.text = Score.highScore.ToString ();
		endScoreGUIText.text = Score.score.ToString ();
	}
}