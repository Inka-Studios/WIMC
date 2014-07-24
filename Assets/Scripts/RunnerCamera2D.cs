using UnityEngine;
using System.Collections;

public class RunnerCamera2D : MonoBehaviour {

	// Public variables
	public Transform player;

	void Update() {
		transform.position = new Vector3(player.position.x + 6, 0, -10);
	}
}
