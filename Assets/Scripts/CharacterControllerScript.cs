using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	// Public Variables
	public float maxSpeed = 10f;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 700;

	// Private Variables
	private bool _facingRight = true;
	private Animator _anim;
	private bool _grounded = false;
	private float _groundRadius = 0.2f;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_grounded = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);
		_anim.SetBool("Ground", _grounded);

		_anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis ("Horizontal");

		_anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !_facingRight) {
			Flip();
		} else if (move < 0 && _facingRight) {
			Flip();
		}
	}

	void Update() {
		if (_grounded && Input.GetKeyDown(KeyCode.Space)) {
			_anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		_facingRight = !_facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
