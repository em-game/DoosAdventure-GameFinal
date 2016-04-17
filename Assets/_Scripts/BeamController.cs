using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeamController : MonoBehaviour {
	//public instance variables
	public float speed;
	public GameObject Explosion;

	GameObject Hud;

	// Use this for initialization
	void Start () {
		Hud = GameObject.FindWithTag ("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 position = transform.position;

		position = new Vector2 (position.x + this.speed, position.y);
		transform.position = position;


		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		if (transform.position.x > max.x) {			
			Destroy (gameObject);
		}

	
	}


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Star")) {
			Destroy (gameObject);

		}

		if (other.gameObject.CompareTag ("FrogEnemy")) {
			Hud.GetComponent<HUD> ().curScore += 85;
			Hud.GetComponent<HUD> ()._audioSources [9].Play ();
			PlayExplosion ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("GhostEnemy")) {
			Hud.GetComponent<HUD> ().curScore += 75;
			Hud.GetComponent<HUD> ()._audioSources [10].Play ();
			PlayExplosion ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	void PlayExplosion(){
		GameObject _explosion = (GameObject)Instantiate (Explosion);

		_explosion.transform.position = transform.position;
	}
}
