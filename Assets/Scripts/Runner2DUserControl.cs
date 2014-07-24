using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RunnerCharacter2D))]
public class Runner2DUserControl : MonoBehaviour {

	// Public variables


	// Private Variables
	private RunnerCharacter2D _character;
	private bool _jump;
	private bool _hasRotten;
	private bool _finished;
	private int _moves;

	void Awake() {
		_character = GetComponent<RunnerCharacter2D>();
	}

	void Update() {
		if (Input.GetButtonDown("Jump")) {
			_jump = true;
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
		if (HUDScript.startGame == true) {
			if (HUDScript.finishGame == false) {
				_character.Move (_jump, 1);
				
				_jump = false;
			}
		}
	}
}
