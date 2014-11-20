﻿using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class UnityChan2DController : MonoBehaviour
{
    public float maxSpeed = 10f;
    public float jumpPower = 1000f;
    public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);
	public int coin = 1;

    public LayerMask whatIsGround;

    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private const float m_centerY = 1.5f;

    private State m_state = State.Normal;

	//ジャンプする回数
	private int restJumps = 2;

	// 床の移動スピード
	public float speed = 1;

    void Reset()
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
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

	void Start () {
		Moves (transform.right);
		
	}

    void Update()
    {
        if (m_state != State.Damaged)
        {

			for (int i = 0; i < Input.touchCount; i++) {
				
				// タッチ情報を取得する
				Touch touch = Input.GetTouch (i);
				
				// ゲーム中ではなく、タッチ直後であればtrueを返す。
				if (touch.phase == TouchPhase.Began) {
					Move(true);
				}
			}
			
			
			//float x = Input.GetAxis("Horizontal");
			bool jump = Input.GetButtonDown("Jump");
			//Move(x, jump);
			Move(jump);
        }
    }

		void Moves (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}

	void Move(bool jump)
    {
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
			if(restJumps == 1){
				m_animator.SetTrigger("Jump");
           	 	SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
           		m_rigidbody2D.AddForce(Vector2.up * jumpPower * 0.5f);

				restJumps--;
	

				print ("restJumps:"+restJumps);}
			else{
				m_animator.SetTrigger("Jump");
				SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
				m_rigidbody2D.AddForce(Vector2.up * jumpPower);
				
				restJumps--;
				
				
				print ("restJumps:"+restJumps);
			}
        }

	//	if(m_isGround){
	//		restJumps = 1;
	//	}

		//高さ制限
		Vector2 pos = transform.position;
		
		Vector2 min = new Vector2(0, -5);
		
		Vector2 max = new Vector2(0, 1.5f);
		
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		transform.position = pos;
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 groundCheck = new Vector2(pos.x, pos.y - (m_centerY * transform.localScale.y));
        Vector2 groundArea = new Vector2(m_boxcollier2D.size.x * 0.49f, 0.05f);

        m_isGround = Physics2D.OverlapArea(groundCheck + groundArea, groundCheck - groundArea, whatIsGround);
        m_animator.SetBool("isGround", m_isGround);
    }

		void OnTriggerEnter2D(Collider2D c){
			if(c.tag == "Ground"){
			restJumps = 2;
			print ("error");
//			string layerName = LayerMask.LayerToName (c.gameObject.layer);
			if (c.tag == "Coin") {
			Destroy (c.gameObject);
//				FindObjectOfType<Score>().AddPoint();

			}
		}
	}
	void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "DamageObject" && m_state == State.Normal)
        {
            m_state = State.Damaged;
            StartCoroutine(INTERNAL_OnDamage());
        }
		if (other.tag == "Coin") {
			Destroy (other.gameObject);
			//				FindObjectOfType<Score>().AddPoint();
			//if(other.tag == "Ground"){
			//	restJumps = 2;
			//	print ("error");
			//}
		}
		}

    IEnumerator INTERNAL_OnDamage()
    {
        m_animator.Play(m_isGround ? "Damage" : "AirDamage");
        m_animator.Play("Idle");

        SendMessage("OnDamage", SendMessageOptions.DontRequireReceiver);

        m_rigidbody2D.velocity = new Vector2(transform.right.x * backwardForce.x, transform.up.y * backwardForce.y);

        yield return new WaitForSeconds(.2f);

        while (m_isGround == false)
        {
            yield return new WaitForFixedUpdate();
        }
        m_animator.SetTrigger("Invincible Mode");
        m_state = State.Invincible;
    }

    void OnFinishedInvincibleMode()
    {
        m_state = State.Normal;
    }

    enum State
    {
        Normal,
        Damaged,
        Invincible,
    }
}