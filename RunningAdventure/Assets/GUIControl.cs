using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	public Texture2D icon;

	public GUISkin skin;
	
	void OnGUI ()
	{
		GUI.skin = skin;

		if (GUI.Button (new Rect (630,10, 100, 50), icon))
		{
			print ("アイコンをクリックしました");
		}

	}
	
}