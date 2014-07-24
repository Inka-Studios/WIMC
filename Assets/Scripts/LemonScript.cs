using UnityEngine;
using System.Collections;
using PathologicalGames;

public class LemonScript : MonoBehaviour {

	// Public variables

	// Private variables
	private HUDScript _hud;

	void Start() {
		_hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			_hud.LemonCatch();
			PoolManager.Pools["RunnerPool"].Despawn (this.transform);
		}
	}
}
