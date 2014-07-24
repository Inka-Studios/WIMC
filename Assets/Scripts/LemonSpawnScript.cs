using UnityEngine;
using System.Collections;
using PathologicalGames;

public class LemonSpawnScript : MonoBehaviour {

	// Public Variables
	public Transform unitPrefab;

	// Private variables
	[SerializeField] private float _spawnMin;
	[SerializeField] private float _spawnMax;
	private int _lemons;

	public void Spawning() {
		Vector3 pos = transform.position;
		while (_lemons < 4) {
			PoolManager.Pools["RunnerPool"].Spawn (unitPrefab, pos, Quaternion.identity);
			pos.x += 1.5f; 
			_lemons += 1;
		}
		_lemons = 0;
		Debug.Log ("Lemon counter is: " + _lemons);
		Invoke ("Spawning", Random.Range(_spawnMin, _spawnMax));
	}
}
