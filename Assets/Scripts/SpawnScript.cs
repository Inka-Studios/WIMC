using UnityEngine;
using System.Collections;
using PathologicalGames;

public class SpawnScript : MonoBehaviour {

	// Public Variables
	public Transform unitPrefab;

	// Private variables
	[SerializeField] private float _spawnMin;
	[SerializeField] private float _spawnMax;

	void Start() {
		Spawn ();
	}

	void Spawn() {
		PoolManager.Pools["RunnerPool"].Spawn (unitPrefab, transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range(_spawnMin, _spawnMax));
	}

}
