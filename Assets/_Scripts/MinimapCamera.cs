using UnityEngine;
using System.Collections;

public class MinimapCamera : MonoBehaviour {
	public Camera miniCamera;

	private bool _cheatKey;

	// Use this for initialization
	void Start () {
		miniCamera.enabled = false;	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Submit"))
		{
			this._cheatKey = !this._cheatKey;
		}

		if (this._cheatKey) {
			miniCamera.enabled = true;			
		}

		if (!this._cheatKey) {
			miniCamera.enabled = false;
		}
	
	}
}
