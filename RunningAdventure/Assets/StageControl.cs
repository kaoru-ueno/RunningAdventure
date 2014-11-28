using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour {

	public GUIText DistGUIText;
	public GUIText GameEndGUIText;
	public GUITexture GameEndSCGUITexture;
	private GameObject main_camera = null;

	void Start () {

		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

		GameObject.Find("Dist").guiText.text = "";
		GameObject.Find("GameEnd").guiText.text = "";
		//GameObject.Find("GameEndSC").guiTexture.enabled = false;
	}
	
	void Update () {
		Vector3	camera_position = this.main_camera.transform.position;
		DistGUIText.text = camera_position.x.ToString("0") + " m";
		  
	}

	public void gameEnd(){
		GameEndGUIText.guiText.color = Color.red;
		GameEndGUIText.text = "GAME OVER";
	}

	public void gameEndSC()
	{
		//GameObject.Find("GameEndSC").guiTexture.enabled = true;
	}
}

