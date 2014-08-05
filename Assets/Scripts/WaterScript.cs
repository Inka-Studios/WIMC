using UnityEngine;
using System.Collections;
using PathologicalGames;

public class WaterScript : MonoBehaviour {

	// Private variables
	private RunnerCharacter2D _char;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			_char = GameObject.Find("Hastu").GetComponent<RunnerCharacter2D>();
			_char.FreshWater();
			PoolManager.Pools["RunnerPool"].Despawn (this.transform);
		}
	}
}
