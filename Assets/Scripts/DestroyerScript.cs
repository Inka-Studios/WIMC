using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;

public class DestroyerScript : MonoBehaviour {

	//Public Variables
	public List<Transform> prefabList1;
	public List<Transform> prefabList2;
	public List<Transform> prefabList3;
	public List<Transform> prefabList4;
	public List<Transform> prefabAirList; 

	//Private Variables
	private int numBGPanels = 2;
	private RunnerCharacter2D _char2D;
	private float groundWidth = 23.1f;
	private string groundValue = "GroundFloor1";
	private Vector3 groundPos;
	private Transform _unitPrefab;
	private Transform _airUnitPrefab;

	void Start() {
		_char2D = GameObject.Find("Hastu").GetComponent<RunnerCharacter2D>();
	}

	void OnTriggerEnter2D (Collider2D derezzed) {
		if (derezzed.tag == "Player") {
			//Debug.Log ("Script activated");
			_char2D.Falling();
			//Debug.Break();
			//return;
		}
		if (derezzed.tag == "GroundObjects") {
			//Debug.Log ("Triggered: " + derezzed.name);

			Vector3 pos = derezzed.transform.position;
			pos.x += groundWidth * numBGPanels;

			groundPos = pos;

			PoolManager.Pools["RunnerPool"].Despawn(derezzed.transform);
			StartCoroutine(randomSpawn());
			//PoolManager.Pools["RunnerPool"].Spawn (unitPrefab, pos, Quaternion.identity);

	    }
		if (derezzed.tag == "AirGround") {
			//Debug.Log ("Triggered: " + derezzed.name);
			
			PoolManager.Pools["RunnerPool"].Despawn(derezzed.transform);
			//StartCoroutine(randomSpawn());
			//PoolManager.Pools["RunnerPool"].Spawn (unitPrefab, pos, Quaternion.identity);
			
		}
		if (derezzed.tag == "OtherObjects") {
			PoolManager.Pools["RunnerPool"].Despawn (derezzed.transform);
			//Debug.Log ("Despawned: " + derezzed.name);
		}
	}

	public IEnumerator randomSpawn () {
		switch (groundValue) {
			case ("GroundFloor1"): {
				int prefabIndex = UnityEngine.Random.Range (0,2);
				_unitPrefab = prefabList1[prefabIndex];
				if (prefabIndex == 0) {
					groundValue = "GroundFloor1";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
				}
				else {
					groundValue = "GroundFloor2";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[0];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				Debug.Log ("Ground Value is: " + groundValue);
				break;
			}
			case ("GroundFloor2"): {
				int prefabIndex = UnityEngine.Random.Range (0,2);
				_unitPrefab = prefabList2[prefabIndex];
				if (prefabIndex == 0) {
					groundValue = "GroundFloor3";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[1];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				else {
					groundValue = "GroundFloor4";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[2];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				Debug.Log ("Ground Value is: " + groundValue);
				break;
			}
			case ("GroundFloor3"): {
				int prefabIndex = UnityEngine.Random.Range (0,2);
				_unitPrefab = prefabList3[prefabIndex];
				if (prefabIndex == 0) {
					groundValue = "GroundFloor3";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[1];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				else {
					groundValue = "GroundFloor4";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[2];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				Debug.Log ("Ground Value is: " + groundValue);
				break;
			}
			case ("GroundFloor4"): {
				int prefabIndex = UnityEngine.Random.Range (0,2);
				_unitPrefab = prefabList4[prefabIndex];
				if (prefabIndex == 0) {
					groundValue = "GroundFloor1";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
				}
				else {
					groundValue = "GroundFloor2";
					PoolManager.Pools["RunnerPool"].Spawn (_unitPrefab, groundPos, Quaternion.identity);
					_airUnitPrefab = prefabAirList[0];
					groundPos.y += 5.0f;
					PoolManager.Pools["RunnerPool"].Spawn (_airUnitPrefab, groundPos, Quaternion.identity);
				}
				//Debug.Log ("Ground Value is: " + groundValue);
				break;
			}
		}
		yield return null;
	}
}