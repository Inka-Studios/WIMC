using UnityEngine;
using System.Collections;

public class RunnerCharacter2D : MonoBehaviour
{

		// Public variables
		public Transform groundCheck;
		public UISlider freshBar;
		public GameObject losingScreen;

		// Private variables
		private bool _facingRight = true;
		[SerializeField]
		private float
				_maxSpeed = 10f;
		[SerializeField]
		private float
				_jumpForce = 400f;
		private bool _airControl = false;
		[SerializeField]
		private LayerMask
				_whatIsGround;
		private float _groundedRadius = 0.2f;
		private bool _grounded = false;
		private Animator _anim;
		[SerializeField]
		private float
				_maxFresh;
		private float _freshness;
		private float _waterValue = 5.0f;
		private float _howFresh;
		private bool _postedScore = false;

		void Awake ()
		{
				_anim = GetComponent<Animator> ();
				_freshness = _maxFresh;
		}

		void Start ()
		{
				_postedScore = false;
		}

		void FixedUpdate ()
		{
				_grounded = Physics2D.OverlapCircle (groundCheck.position, _groundedRadius, _whatIsGround);
				_anim.SetBool ("Ground", _grounded);
				_anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		}

		void Update ()
		{
				if (HUDScript.startGame == true) {
						_freshness -= Time.deltaTime;
						_howFresh = _freshness / _maxFresh;
						freshBar.value = _howFresh;
						if (freshBar.value <= 0) {
								if (_postedScore == false) {
										StartCoroutine (OnLosing ());
										_postedScore = true;
								}
						}
				}
		}

		public void Move (bool _jump, float move)
		{
				if (_grounded || _airControl) {
						_anim.SetFloat ("Speed", Mathf.Abs (move));
						rigidbody2D.velocity = new Vector2 (move * _maxSpeed, rigidbody2D.velocity.y);
						if (move > 0 && !_facingRight) {
								Flip ();
						} else if (move < 0 && _facingRight) {
								Flip ();
						}
				}

				if (_grounded && _jump) {
						_anim.SetBool ("Ground", false);
						rigidbody2D.AddForce (new Vector2 (0f, _jumpForce));
				}
		}

		void Flip ()
		{
				// Switch the way the player is labelled as facing.
				_facingRight = !_facingRight;
		
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}

		public void NotFresh ()
		{
				StartCoroutine (PlayDeathOnce ("nFresh"));
		}

		public void Falling ()
		{
				freshBar.value = 0;
				StartCoroutine (OnLosing ());
		}

		public IEnumerator PlayDeathOnce (string paranName)
		{
				_anim.SetBool (paranName, true);
				yield return new WaitForSeconds (3.0f);
				_anim.SetBool (paranName, false);
		}

		public void FreshWater ()
		{
				_freshness = _freshness + _waterValue;
				if (_freshness > 20) {
						_freshness = 20;
				}
		}

		public IEnumerator OnLosing ()
		{
				NotFresh ();
				HUDScript.finishGame = true;
				HUDScript.Finished ();
				PostScores varPostScore = GameObject.Find ("ControladorHighScores").GetComponent<PostScores> ();
				int tempScore = HUDScript.getScore (); 
				yield return new WaitForSeconds (3.0f);
				NGUITools.SetActive (losingScreen, true);
				Debug.Log ("Posting score..");
				
				if (varPostScore != null) {
						StartCoroutine (varPostScore.PostScore ("Test Subject", tempScore));
				} else
						Debug.LogError ("Error: en carga de PostScores");
		}
}
