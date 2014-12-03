using UnityEngine;
using System.Collections;

public class StopControl : MonoBehaviour {

	Rect _rect = new Rect(-140,-5,350,100);

	private GameObject Player = null;

	//private int Count = 0;
	public static bool is_playing = true;

	//public Texture2D icon;
	
	//public GUISkin skin;
	public GUIStyle ButtonStyle;
	public Texture2D btnStopTexture;
	public Texture2D btnStartTexture;
	private int ButtonWidth = 80;
	private int ButtonHeight = 80;

	public Animator animator;

	UnityChan2DController unityChan2DController;

	//public int speed = 0;

	void Start () 
	{
			this.Player = GameObject.FindGameObjectWithTag("Player");
			unityChan2DController = Player.GetComponent<UnityChan2DController> ();
	}

	//void Update () 
	//{
		//speed = unityChan2DController.speedlevel;
	//}
	void Update () 
	{
	/*for (int i = 0; i < Input.touchCount; i++)
		{
			
			// タッチ情報を取得する
			Touch touch = Input.GetTouch (i);
			Vector2 newVec = new Vector2(touch.position.x,Screen.height - touch.position.y);
			
			//タッチ直後であればtrueを返す
			if (touch.phase == TouchPhase.Began)
			{
				//Rectとタッチの位置を判定
				if(newVec.x >= _rect.xMin && 
				   newVec.x < _rect.xMax &&
				   newVec.y >=  _rect.yMin && 
				   newVec.y <_rect.yMax)
				{
					if(Count == 1)
					{
						Player.rigidbody2D.gravityScale = 3.5f;
						Player.GetComponent<UnityChan2DController>().enabled = true;
						if(UnityChan2DController.speedlevel == 1)
						{
							Player.rigidbody2D.velocity = transform.right * 5;
						}
						
						if(UnityChan2DController.speedlevel == 2)
						{
							Player.rigidbody2D.velocity = transform.right * 5 * 1.5f;
						}
						
						if(UnityChan2DController.speedlevel == 3)
						{
							Player.rigidbody2D.velocity = transform.right * 5 * 2f;
						}
						//Player.animation.Play();
						animator.SetBool("Stop", false);
						
						Count = 0;
						
						//print ("アイコンをクリックしました");
					}
					else
					{
						Player.rigidbody2D.gravityScale = 0.0f;
						Player.GetComponent<UnityChan2DController>().enabled = false;
						Player.rigidbody2D.velocity = transform.right * 0;
						//Player.animation.Stop();
						animator.SetBool("Stop", true);
						
						Count++;
						
						//print ("アイコンをクリックしました");
					}
				}
			}
		}*/
	}

/*public IEnumerator Stop()
	{
		Time.timeScale = 0.0f ;
		Count++;
		print ("Count1");
		yield return new WaitForSeconds (2.0f);
	}

	public IEnumerator Resumption()
	{
		Time.timeScale = 1.0f;
		Count = 0;
		print ("Count2");
		yield return new WaitForSeconds (2.0f);
	}*/
void OnGUI ()
	{
		if (is_playing)
		{
			if (GUI.Button (new Rect(Screen.width - ButtonWidth, 0, ButtonWidth, ButtonHeight), btnStopTexture, ButtonStyle))
			{	
				if(UnityChan2DController.jumpconstraint > 70 || UnityChan2DController.bonusflg == false)
				{
				Player.rigidbody2D.gravityScale = 0.0f;
				Player.GetComponent<UnityChan2DController>().enabled = false;
				Player.rigidbody2D.velocity = transform.right * 0;
				//Player.animation.Stop();
				animator.SetBool("Stop", true);
			//if(Count == 1)
			//{

				is_playing = false;
				//Count = 0;

				//print ("アイコンをクリックしました");
				}
			}
		} 
		else {
			if (GUI.Button (new Rect(Screen.width - ButtonWidth, 0, ButtonWidth, ButtonHeight), btnStartTexture, ButtonStyle))
			{	
				if(UnityChan2DController.jumpconstraint > 70 || UnityChan2DController.bonusflg == false)
				{
				Player.rigidbody2D.gravityScale = 3.5f;
				Player.GetComponent<UnityChan2DController>().enabled = true;
				//FindObjectOfType<UnityChan2DController>().Moves (UnityChan2DController.speedlevel);
				//Player.animation.Play();
				animator.SetBool("Stop", false);

				is_playing = true;
				//Count++;

					//print ("アイコンをクリックしました");
				}
			}
		}
	}
}
