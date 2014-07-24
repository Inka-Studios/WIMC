using UnityEngine;
using System.Collections;
using PathologicalGames;

public class DestroyerScript : MonoBehaviour {

	//Public Variables
	public Transform unitPrefab;

	//Private Variables
	private int numBGPanels = 2;
	private RunnerCharacter2D _char2D;

	void Start() {
		_char2D = GameObject.Find("Character").GetComponent<RunnerCharacter2D>();
	}

	void OnTriggerEnter2D (Collider2D derezzed) {
		if (derezzed.tag == "Player") {
			Debug.Log ("Script activated");
			_char2D.Falling();
			//Debug.Break();
			//return;
		}
		if (derezzed.tag == "GroundObjects") {
			Debug.Log ("Triggered: " + derezzed.name);

			float widthofObject = ((BoxCollider2D)derezzed).size.x;
			Vector3 pos = derezzed.transform.position;
			pos.x += widthofObject * numBGPanels;

			PoolManager.Pools["RunnerPool"].Despawn(derezzed.transform);
			PoolManager.Pools["RunnerPool"].Spawn (unitPrefab, pos, Quaternion.identity);

	    }
		if (derezzed.tag == "OtherObjects") {
			PoolManager.Pools["RunnerPool"].Despawn (derezzed.transform);
			Debug.Log ("Despawned: " + derezzed.name);
		}
	}
}