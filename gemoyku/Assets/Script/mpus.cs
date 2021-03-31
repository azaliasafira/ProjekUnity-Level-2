using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class mpus : MonoBehaviour {

	Text infocoin;
	Rigidbody2D rb;
	Animator anim;
	bool facingRight = true;
	float velX, speed = 7f;
	public float jumpValue;
	bool isHurt, isDead;
	public int nyawa;
	public int coin;
	Vector2 mulai;
	public bool ulang;
	public GameObject menang, kalah;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		mulai = transform.position;
		infocoin = GameObject.Find("Skor").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		infocoin.text = "SKOR = " + coin.ToString();
		if(ulang == true){
			transform.position = mulai;
			ulang = false;
		}

		if(nyawa == 1){
			anim.SetTrigger ("isDead");
			kalah.SetActive(true);
		} else if (coin >= 91){
			menang.SetActive(true);
		}

		if (Input.GetKey (KeyCode.LeftShift))
			speed = 9f;
		else
			speed = 7f;

		if (Input.GetButtonDown ("Jump") && rb.velocity.y == 0)
			rb.AddForce (Vector2.up * jumpValue);

		AnimationState ();
		if (!isDead)
			velX = Input.GetAxisRaw ("Horizontal") * speed;
	}

	void FixedUpdate(){
		if (!isHurt)
			rb.velocity = new Vector2 (velX, rb.velocity.y);
	}

	void LateUpdate(){
		CheckWhereToFace ();
	}

	void CheckWhereToFace(){
		Vector3 localScale = transform.localScale;
		if (velX > 0) {
			facingRight = true;
		} else if (velX < 0) {
			facingRight = false;
		}
		if (((facingRight) && (localScale.x < 0)) || (!facingRight) && (localScale.x > 0)) {
			localScale.x *= -1;
		}
		transform.localScale = localScale;
	}

	void AnimationState(){
		if (velX == 0) {
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isRunning", false);
		}
		if (Mathf.Abs (velX) == 7)
			anim.SetBool ("isWalking", true);
		if (Mathf.Abs (velX) == 9)
			anim.SetBool ("isRunning", true);
		else
			anim.SetBool ("isRunning", false);

		if (rb.velocity.y == 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", false);
		}
		if (Mathf.Abs (velX) == 7 && rb.velocity.y == 0)
			anim.SetBool ("isWalking", true);
		if (Mathf.Abs (velX) == 9 && rb.velocity.y == 0)
			anim.SetBool ("isRunning", true);
		// else
		// 	anim.SetBool ("isRunning", false);
		// if (Input.GetKey (KeyCode.DownArrow) && Mathf.Abs (velX) == 9)
		// 	anim.SetBool ("isSliding", true);
		// else
		// 	anim.SetBool ("isRunning", false);
		if (rb.velocity.y > 0)
			anim.SetBool ("isJumping", true);
		if (rb.velocity.y < 0) {
			anim.SetBool ("isJumping", false);
			anim.SetBool ("isFalling", true);
		}
	}

	// void OnTriggerEnter2D(Collider2D col){
	// 	if (col.CompareTag("musuh")) {
	// 		health -= 1;
	// 	}
	// 	if (col.CompareTag("musuh") && health > 0) {
	// 		anim.SetTrigger ("isHurt");
	// 		StartCoroutine ("Hurth");
	// 	} else {
	// 		velX = 0;
	// 		isDead = true;
	// 		anim.SetTrigger ("isDead");
	// 	}
	// }

	// IEnumerator Hurt(){
	// 	isHurt = true;
	// 	rb.velocity = Vector2.zero;
	// 	if (facingRight)
	// 		rb.AddForce (new Vector2 (-100f, 100f));
	// 	else
	// 		rb.AddForce (new Vector2 (100f, 100f));
	// 	yield return new WaitForSeconds (0.5f);
	// 	isHurt = false;
	// }
}
