using UnityEngine;
using System.Collections;

public class StageControl : MonoBehaviour {

	public GUIText DistGUIText;
	public GUIText GameEndGUIText;
	private GameObject main_camera = null;

	void Start () {

		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

		GameObject.Find("Dist").guiText.text = "";
		GameObject.Find("GameEnd").guiText.text = "";
	}
	
	void Update () {
		Vector3	camera_position = this.main_camera.transform.position;
		DistGUIText.text = camera_position.x.ToString("0") + " m";
		  
	}

	public void gameEnd(){
		GameEndGUIText.guiText.color = Color.red;
		GameEndGUIText.text = "GAME OVER";
	}
}

