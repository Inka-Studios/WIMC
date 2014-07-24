using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	// Public variables
	public UILabel scoreLabel;
	public UILabel lemonLabel;
	public UILabel startCount;
	public UILabel scoreLabelLosing;

	/// Private variables
	private bool _finish;
	private int _lemonCount;
	private LemonSpawnScript _spawning;

	// Public Static variables
	public static bool finishGame;
	public static bool startGame;
	private static float _score;
	private static bool _finished;

	void Start() {
		startGame = false;
		StartCoroutine(StartingIt());
		finishGame = false;
		_score=0;
		_finished=false;
		_spawning = GameObject.Find("Lemon Spawn").GetComponent<LemonSpawnScript>();
	}

	void Update() {
		if (startGame == true) {
			_score += Time.deltaTime;
			if (finishGame == false) {
				scoreLabel.text = (int) (_score * 10) + " m.";
			} else {
				//scoreLabel.text = scoreLabel.text;
				scoreLabelLosing.text = scoreLabel.text;
			}
		}
	}

	public void LemonCatch() {
		_lemonCount = _lemonCount + 1;
		lemonLabel.text = _lemonCount.ToString ();
	}

	IEnumerator StartingIt() {
		startCount.text = "3";
		yield return new WaitForSeconds(1f);
		startCount.text = "2";
		yield return new WaitForSeconds(1f);
		startCount.text = "1";
		yield return new WaitForSeconds(1f);
		startCount.text = "Go!";
		startGame = true;
		yield return new WaitForSeconds(0.8f);
		startCount.enabled = false;
		_spawning.Spawning();
		yield return null;
	}
	static public  int getScore(){
		return (int) (_score * 10);
	}
	static public  void Finished(){
		_finished=true;
	}
}
