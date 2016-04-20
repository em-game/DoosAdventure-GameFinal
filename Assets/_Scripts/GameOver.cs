using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public Text txtScore;


	// Use this for initialization
	void Start () {
		this.txtScore.text = "High Score: " + GlobalControl.Instance.Score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
