using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour {

	public GUIText DistGUIText;
	public GameObject GameEndGameObject;
	private GameObject main_camera = null;
	private int ButtonWidth = 250;
	private int ButtonHeight = 65;
	public GUIStyle retryButtonStyle;


	void Start ()
	{

		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

		GameObject.Find("Dist").guiText.text = "";
		//GameObject.Find("GameEnd").guiText.text = "";
		GameObject.Find("gray").renderer.enabled  = false;
		//GameObject.Find("GameEnd2").guiText.text = "";

	}


	void Update () 
	{
		Vector3	camera_position = this.main_camera.transform.position;

		if(UnityChan2DController.gameflg)
		{
			Debug.Log("gameflg " + UnityChan2DController.gameflg); 
			DistGUIText.text = camera_position.x.ToString("0");
		} 
	}


	public void gameEnd()
	{
		//GameEndGUIText.guiText.color = Color.red;
		//GameEndGUIText.text = "GAME OVER";
		//GameObject.Find("GameEnd2").guiText.text = "画面タップで結果発表！";
		GameObject.Find("gameoverTxt").renderer.enabled  = true;
		GameObject.Find("Result").renderer.enabled  = true;
	}


	public void gameEndSC()
	{
		Instantiate (GameEndGameObject, transform.position, Quaternion.identity);
	}


	void OnGUI () 
	{
		//drawMenu();
		if (GUI.Button(new Rect(Screen.width / 2 - ButtonWidth / 2, (Screen.height / 2 - ButtonHeight / 2)+150, ButtonWidth, ButtonHeight), "", retryButtonStyle))
		{
			print ("スタート画面に戻りまーす");
			Application.LoadLevel ("Start");
			FindObjectOfType<Score>(). Save ();
			FindObjectOfType<UnityChan2DController>().Reset();
			//Debug.Log("bonusgauge" + Score.bonusgauge);
		}
		
	}
}

