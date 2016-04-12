/*----------------------------------------------------------------------------
Source file name: HUD.cs
Author's name: Jihee Seo
Last modified by: Jihee Seo
Last modified date: Feb 26, 2016
Program description: This is for controlling of player's lives
Revision history: 0.0 - set up 
                  0.1 - made basic method
----------------------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	//Declare public vairables
	public Sprite[] HeartSprites;
	public Image HeartUI_1;
	public Image HeartUI_2;
	public Image HeartUI_3;
	public Image HeartUI_4;
	public Text lblScore;

	//Health states and scores

	public int maxHealth = 4;

	public int curScore = 0;
	public int curHealth = 4;


	//Game over UI
	public GameObject GameoverUI;
	public GameObject GameClearUI;

	//Set audio variables
	public AudioSource[] _audioSources;
	private AudioSource _jumpSound;
	private AudioSource _coinSound;
	private AudioSource _powerUpSound;
	private AudioSource _deadSound;
	private AudioSource _hurtSound;
	private AudioSource _gameover;
	private AudioSource _backSound;
	private AudioSource _gameClear;



	public PlayerController _Player;

	//Declare private variables
	private string _txtScore;



	// Use this for initialization
	void Start () {
		this.curHealth = this.maxHealth;
		this.curScore = 0;

		// Setup AudioSources
		//this._audioSources = gameObject.GetComponents<AudioSource>();
		this._coinSound = this._audioSources[0];
		this._deadSound = this._audioSources[1];
		this._gameClear = this._audioSources[2];
		this._gameover = this._audioSources[3];
		this._hurtSound = this._audioSources[4];
		this._backSound = this._audioSources[5];
		this._jumpSound = this._audioSources[6];
		this._powerUpSound = this._audioSources[7];

		this.GameoverUI.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		this.DrawHUD(this.curHealth);
		this.DrawScore(this.curScore);

		if (this.curHealth > this.maxHealth)
		{
			this.curHealth = this.maxHealth;
		}

		if(this.curHealth <= 0)
		{
			Die();
		}
	}

	// Draw Current heart depends on player's current health score
	void DrawHUD(int curHealth)
	{
		switch (curHealth)
		{
		case 0:
			HeartUI_1.sprite = HeartSprites[1];
			HeartUI_2.sprite = HeartSprites[1];
			HeartUI_3.sprite = HeartSprites[1];
			HeartUI_4.sprite = HeartSprites[1];
			break;
		case 1:
			HeartUI_1.sprite = HeartSprites[0];
			HeartUI_2.sprite = HeartSprites[1];
			HeartUI_3.sprite = HeartSprites[1];
			HeartUI_4.sprite = HeartSprites[1];
			break;
		case 2:
			HeartUI_1.sprite = HeartSprites[0];
			HeartUI_2.sprite = HeartSprites[0];
			HeartUI_3.sprite = HeartSprites[1];
			HeartUI_4.sprite = HeartSprites[1];
			break;
		case 3:
			HeartUI_1.sprite = HeartSprites[0];
			HeartUI_2.sprite = HeartSprites[0];
			HeartUI_3.sprite = HeartSprites[0];
			HeartUI_4.sprite = HeartSprites[1];
			break;
		case 4:
		default:
			HeartUI_1.sprite = HeartSprites[0];
			HeartUI_2.sprite = HeartSprites[0];
			HeartUI_3.sprite = HeartSprites[0];
			HeartUI_4.sprite = HeartSprites[0];
			break;
		}
	}

	void DrawScore(int curScore)
	{
		this._txtScore = "Score: " + this.curScore;
		this.lblScore.text = this._txtScore;
	}

	public void GameClear()
	{
		this._backSound.Stop();
		this._gameClear.Play();
		this.GameClearUI.SetActive(true);

	}

	public void Die()
	{
		this._backSound.Stop();
		this._gameover.Play();
		this.GameoverUI.SetActive(true);
		this.lblScore.text = "Score: " + this.curScore;
		this.lblScore.enabled = true;

	}
}
