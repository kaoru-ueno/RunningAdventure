using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class UnityChan2DController : MonoBehaviour
{
    public float maxSpeed = 10f;
//	Debug.Log("highScore" + highScore);

    public float jumpPower = 1000f;
    public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);
	public int coin = 1;
	public int life = 0;
    public LayerMask whatIsGround;

    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private const float m_centerY = 1.5f;

    private State m_state = State.Normal;

	//ジャンプする回数
	private int restJumps = 2;

	// 移動スピード
	public float speed = 1;

	private GameObject main_camera = null;

	//スピードを変化させる値
	public float speedometer = 100;

	//スピードの段階
	public static int speedlevel = 1;

	//ゲームの終わりを判断するフラッグ
	public static bool gameflg = true;

	//ボーナスステージの終わりを判断するフラッグ
	public static bool bonusflg = false;

	//どれだけスコアが溜まったらボーナスステージにするかの値
	public static  int bonuscount = 50;
	
	//ジャンプの制限時間カウント
	public static int jumpconstraint = 0;

	//ボーナスジャンプ回数
	public static int bonusJump = 0;

	private int GameSC = 0;

	private bool gamed = true;


  public void Reset()
    {
        Awake();

        // UnityChan2DController
        maxSpeed = 10f;
        jumpPower = 1000;
        backwardForce = new Vector2(-4.5f, 5.4f);
        whatIsGround = 1 << LayerMask.NameToLayer("Ground");

        // Transform
        transform.localScale = new Vector3(1, 1, 1);

        // Rigidbody2D
        m_rigidbody2D.gravityScale = 3.5f;
        m_rigidbody2D.fixedAngle = true;

        // BoxCollider2D
        m_boxcollier2D.size = new Vector2(1, 2.5f);
        m_boxcollier2D.center = new Vector2(0, -0.25f);

        // Animator
        m_animator.applyRootMotion = false;

		speedlevel = 1;
		gameflg = true;
		bonusflg = false;
		jumpconstraint = 0;
		bonusJump = 0;
		GameSC = 0;
		Score.bonusgauge = 0;
		gamed = true;
    }
	
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }


	void Start () {
		//移動（使っていない）
		//Moves (transform.right);
		
		// カメラのインスタンスを探しておく.

		this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

//		GameObject.Find("Riskhedg").gameObject.collider2D.enabled = false;

	}


    void Update()
    {	

		//オブジェクトすり抜け管理------------------------------------------------------------------------------

		//ボーナスステージが終わっている且つ高さが８以上
		if(bonusflg == false && transform.position.y > 8)
		{
			gameObject.collider2D.isTrigger = true;
			//ypos = false;
		}

		//ボーナスステージが終わっている且つ高さが７以下
		if(gameflg != false && bonusflg == false && transform.position.y < 7)
		{
			gameObject.collider2D.isTrigger = false;
		}

		//ボーナスステージが始まっている且つ高さが５以下
		if(bonusflg == true && transform.position.y < 5)
		{
			gameObject.collider2D.isTrigger = true;

			jumpPower = 12;
		}

		//ボーナスステージが始まっている且つ高さが１０以上
		if(bonusflg == true && transform.position.y > 10)
		{
			gameObject.collider2D.isTrigger = false;
		}
		//if(bonusflg == true && ypos == false && transform.position.y < 15)
		//{

		//	if(transform.position.y > 13) ypos = true;
		//}
		//------------------------------------------------------------------------------

		if(bonusflg == true)
		{
			jumpconstraint++;

			//Debug.Log("jumpconstraint" + jumpconstraint);
		}

		//ボーナスゲージが溜まったら
		if(Score.bonusgauge > bonuscount && gameflg != false && bonusJump < 1)
		{	

			//ボーナスステージスタート
			bonusflg = true;

			//ボーナスゲージリセット
			Score.bonusgauge = 0;



			//ボーナスステージに移動させる
			jumpPower = 50;
			m_animator.SetTrigger("Jump");
			SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
			float jumpHeight = jumpPower;
			float gravity = Mathf.Abs(Physics.gravity.y);
			float velocity = Mathf.Sqrt(2 * gravity * jumpHeight);
			m_rigidbody2D.velocity = Vector2.up * velocity;
			bonusJump++;
			jumpPower = 12;

			//print("bonusflg"+bonusflg);
		}

		Vector3	camera_position = this.main_camera.transform.position;

		//ゲームが終わったら
		if(gameflg == false)
		{
			GameScreen();
		}


		//移動のスクリプト--------------------------------------------------------------
								//if(speedlevel == 1)
								//{
								//	Moves ();
								//}

								if(camera_position.x > speedometer && camera_position.x < speedometer + 1.0f )
								{
									speedlevel = 2;
								}

								//if(speedlevel == 2)
								//{
									//Moves (transform.right * 1.5f);
									//transform.Translate (transform.right * speed * 1.2f);
									
									//print ("speedup");
								//}
								
								
								if(camera_position.x > speedometer && camera_position.x < speedometer * 2 + 1.0f )
								{
									speedlevel = 3;
								}

								//if(speedlevel == 3)
								//{
									//Moves (transform.right * 2f);
									//transform.Translate (transform.right * speed * 1.5f);
									
									//print ("speedup");
								//}
		Moves (speedlevel);
		//--------------------------------------------------------------

		if (jumpconstraint < 70 && bonusflg == true)
		{
			GameObject.Find("kumo_0").renderer.enabled  = true;
		}

		if (jumpconstraint > 70)
		{
			GameObject.Find("kumo_0").renderer.enabled  = false;
		}
       
		if (m_state != State.Damaged)
        {

			for (int i = 0; i < Input.touchCount; i++)
			{
				
				// タッチ情報を取得する
				Touch touch = Input.GetTouch (i);
				
				// ゲーム中ではなく、タッチ直後であればtrueを返す。
				if (gameflg != false && touch.phase == TouchPhase.Began)
				{
					if(jumpconstraint > 70 || bonusflg == false)
					{
						Move(true);
					}

				}
			}
			
			if(jumpconstraint > 70 || bonusflg == false)
			{
			//float x = Input.GetAxis("Horizontal");
			bool jump = Input.GetButtonDown("Jump");
			//Move(x, jump);
			Move(jump);
			}
        }

		//ゲームオーバーの条件
		if(transform.position.y < -8 && gamed)
		{
			//ゲームオーバー画面表示
			FindObjectOfType<StageControl>().gameEnd();

			//カメラを止める
			main_camera.GetComponent<CameraControl2>().enabled = false;

			gameflg = false;

		}
		if(Unikill.enemyjump == true && Unikill.jumpplan < 2){

			jumpPower = 6;
			m_animator.SetTrigger("Jump");
			SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
			float jumpHeight = jumpPower;
			float gravity = Mathf.Abs(Physics.gravity.y);
			float velocity = Mathf.Sqrt(2 * gravity * jumpHeight);
			m_rigidbody2D.velocity = Vector2.up * velocity;
			jumpPower = 12;
			Unikill.enemyjump = false;
			Unikill.jumpplan = 0;

		}

		if(CameraControl2.bonusinv)
		{
			m_state = State.Invincible;
			StartCoroutine (INTERNAL_OnInvincible ());
			CameraControl2.bonusinv = false;
		}

	}

	public void Moves (int s)
	{
		if(s == 1)
		{
			transform.Translate (transform.right * speed);
		}

		if(s == 2)
		{
			transform.Translate (transform.right * speed * 1.2f);
		}

		if(s == 3)
		{
			transform.Translate (transform.right * speed * 1.5f);
		}
		//rigidbody2D.AddForce(direction * speed);
	}


	void Move(bool jump)
    {
		//Vector2 Posi = (Vector2)transform.position + Vector2.right;
      /*  if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
        }

        m_rigidbody2D.velocity = new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y);

        m_animator.SetFloat("Horizontal", move);
        m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        m_animator.SetBool("isGround", m_isGround);
*/
        //if (jump && m_isGround)
		if (jump && restJumps > 0)
        {
			if(restJumps == 1)
			{
				m_animator.SetTrigger("Jump");
           	 	SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
				float jumpHeight = jumpPower / 2;
				float gravity = Mathf.Abs(Physics.gravity.y);
				float velocity = Mathf.Sqrt(2 * gravity * jumpHeight);
				m_rigidbody2D.velocity = Vector2.up * velocity;

				//float angularVelocity = Mathf.PI * gravity / velocity * 2;
				//m_rigidbody2D.angularVelocity = Vector2.up * angularVelocity;

				//m_rigidbody2D.AddForce(Vector2.up * jumpPower);

				restJumps--;
	
				//print ("restJumps:"+restJumps);
			}

			else{
				m_animator.SetTrigger("Jump");
				SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
				float jumpHeight = jumpPower;
				float gravity = Mathf.Abs(Physics.gravity.y);
				float velocity = Mathf.Sqrt(2 * gravity * jumpHeight);
				m_rigidbody2D.velocity = Vector2.up * velocity;
					
				//float angularVelocity = Mathf.PI * gravity / velocity;
				//m_rigidbody2D.angularVelocity = Vector2.up * angularVelocity;

				//m_rigidbody2D.AddForce(Vector2.up * jumpPower);

				restJumps--;
				
				
				//print ("restJumps:"+restJumps);
			}
        }

	//	if(m_isGround){
	//		restJumps = 1;
	//	}

		//高さ制限
		//Vector2 pos = transform.position;
		
		//Vector2 min = new Vector2(0, -2000);

		//Vector2 max = new Vector2(0, 4.0f);
		
		//pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		//transform.position = pos;
    }


    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
        Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);

        m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
        m_animator.SetBool("isGround", m_isGround);
    }


		void OnTriggerEnter2D(Collider2D c)
	{
		if (c.tag == "Ground") 
		{
			restJumps = 2;
			//print ("error");
		}
	}


	void OnTriggerStay2D(Collider2D other)
    {
				if (other.tag == "DamageObject" && m_state == State.Normal) {
						m_state = State.Damaged;
						StartCoroutine (INTERNAL_OnDamage ());

						//ゲームオーバー画面表示
						FindObjectOfType<StageControl> ().gameEnd ();

						gameflg = false;

						//地面をすり抜ける
						gameObject.collider2D.isTrigger = true;

						//カメラを止める
						main_camera.GetComponent<CameraControl2> ().enabled = false;

						

				}
				if (other.tag == "Coin" || other.tag == "Scoin" || other.tag == "Goldcoin") {
						//Destroy(other.gameObject);
						other.gameObject.renderer.enabled = false;
						}

				if (other.tag == "Item") {
//						GetComponent<Item>("item");
//						life += item;
						transform.localScale = new Vector3 (1, 1, 1);
						other.gameObject.renderer.enabled = false;
						m_state = State.Invincible;
						StartCoroutine (INTERNAL_OnInvincible ());
//					GameObject.Find("kumo_0").renderer.enabled  = false;
						GameObject.Find("kumo_0").renderer.enabled  = false;
						
						
				}
		if (other.tag == "UniKill" || other.tag == "Unikill2" || other.tag == "Unikill3")/*　|| other.tag == "Unikill4") */{
						other.gameObject.renderer.enabled = false;
				}
			}


	IEnumerator INTERNAL_OnDamage()
    {
        m_animator.Play(m_isGround ? "Damage" : "AirDamage");
        m_animator.Play("Idle");
	

        SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);

        m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);

        yield return new WaitForSeconds(.5f);

		//Moves (transform.right);

        while (m_isGround == false)
        {
            yield return new WaitForFixedUpdate();
        }
        //m_animator.SetTrigger("Invincible Mode");
       // m_state = State.Invincible;
    }

	IEnumerator INTERNAL_OnInvincible()
	{
		m_animator.Play("Invincible Mode");
		m_animator.Play("Idle");
		
		
		SendMessage("OnInvincible", SendMessageOptions.DontRequireReceiver);

//		GameObject.Find("Riskhedg").gameObject.collider2D.enabled = true;
//		GameObject.Find("kumo_0").renderer.enabled  = true;
		
		//m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);
		
		yield return new WaitForSeconds(.5f);
		
		//Moves (transform.right);
		
		while (m_isGround == false)
		{
			yield return new WaitForFixedUpdate();
		}
		//m_animator.SetTrigger("Invincible Mode");
		// m_state = State.Invincible;
	}


    void OnFinishedInvincibleMode()
   {
    	m_state = State.Normal;
		transform.localScale = new Vector3 (0.7f, 0.7f, 1f);
		GameObject.Find("Riskhedg").gameObject.collider2D.enabled = false;
		GameObject.Find("kumo_0").renderer.enabled  = false;
    }


	public void GameScreen()
	{

		if (gameflg != true && Input.GetMouseButtonDown (0) && GameSC == 0) 
		{
			FindObjectOfType<StageControl> ().gameEndSC ();
			GameObject.Find("gray").renderer.enabled  = true;
			gamed = false;
			GameObject.Find("GameEnd").guiText.text = "";
			GameObject.Find("GameEnd2").guiText.text = "";
			GameSC++;
		}

		for (int i = 0; i < Input.touchCount; i++)
		{
			
			// タッチ情報を取得する
			Touch touch = Input.GetTouch (i);
			
			// ゲーム中ではなく、タッチ直後であればtrueを返す。
			if (gameflg != true && touch.phase == TouchPhase.Began && GameSC == 0)
			{
				FindObjectOfType<StageControl> ().gameEndSC ();
				GameObject.Find("gray").renderer.enabled  = true;
				gamed = false;
				GameObject.Find("GameEnd").guiText.text = "";
				GameObject.Find("GameEnd2").guiText.text = "";
				GameSC++;
			}
		}
	}
    enum State
    {
        Normal,
        Damaged,
        Invincible,
    }
}
