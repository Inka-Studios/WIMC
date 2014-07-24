using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	void OnClick() {
		Application.LoadLevel("Level_Scene");
	}
}
