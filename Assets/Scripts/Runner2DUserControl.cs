using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RunnerCharacter2D))]
public class Runner2DUserControl : MonoBehaviour
{

		// Public variables


		// Private Variables
		private RunnerCharacter2D _character;
		private bool _jump;
		private bool _hasRotten;
		private bool _finished;
		private int _moves;
		private bool isPaused;

		void Awake ()
		{
				_character = GetComponent<RunnerCharacter2D> ();
		}

		void Update ()
		{
				if (Input.GetButtonDown ("Jump")) {
						_jump = true;
				}
				if (Input.GetKeyDown (KeyCode.Escape)) {
						if (isPaused) {
								Time.timeScale = 1;
								isPaused = false;		
						} else {
								isPaused = true;
								Time.timeScale = 0;
						}
				}
				if ( Input.touchCount == 1) {
					_jump = true;
				}
		}

		void FixedUpdate ()
		{
				float h = Input.GetAxis ("Horizontal");
				if (HUDScript.startGame == true) {
						if (HUDScript.finishGame == false) {
								_character.Move (_jump, 1);
				
								_jump = false;
						}
				}
		}
}
