﻿/*----------------------------------------------------------------------------
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
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	public static HUD Instance;


	//Declare public vairables
	public Sprite[] HeartSprites;
	public Image HeartUI_1;
	public Image HeartUI_2;
	public Image HeartUI_3;
	public Image HeartUI_4;
	public Text lblScore;
	public Text lblBossHeart;
    //gameClearText_ and mech var
    public Text gameClearScore;
    public GameObject Boss;


	//Health states and scores

	public int maxHealth = 4;

	public int curScore = 0;
	public int curHealth = 4;

	public int curLevel = 1;

	public int curBossHeart;

	//Game over UI
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
	private AudioSource _starSound;
	private AudioSource _frogSound;
	private AudioSource _ghostSound;
	private bool _paused;


	public PlayerController _Player;

	//Declare private variables
	private string _txtScore;
	private string _txtBossHeart;


	void Awake()
	{
		if (Instance == null)
			Instance = this;

		if (Instance != this)
			Destroy (gameObject);
	}


	// Use this for initialization
	void Start () {

		this.curBossHeart = 10;
		this.curHealth = GlobalControl.Instance.Live;
		this.curLevel = GlobalControl.Instance.Level;
		this.curScore = GlobalControl.Instance.Score;


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
		this._starSound = this._audioSources [8];
		this._frogSound = this._audioSources [9];
		this._ghostSound = this._audioSources [10];


		if (Application.loadedLevelName == "ThirdLevel") {
			this.lblBossHeart.gameObject.SetActive(true);
		}

	}

	// Update is called once per frame
	void Update () {

		//this.curHealth = GlobalControl.Instance.Live;
		//this.curScore = GlobalControl.Instance.Score;


		this.DrawHUD(this.curHealth);
		this.DrawScore(this.curScore);

		this.DrawBossHeart (this.curBossHeart);		


		if (this.curHealth <= 0) {
			Die ();
		}
        // bit of adding, becaseu boss clear == game clear
		if (this.curBossHeart <= 0 ) {

            this.GameClearUI.SetActive(true);
            this.gameClearScore.text = "Score: " + this.curScore;             
            this._backSound.Stop();
            this._gameClear.Play();
           


            Destroy (Boss);

        }

        // boss cheatkey

        if (Input.GetKeyDown("f"))
       {
            if (curLevel == 3)
                {

                curBossHeart = 0;
            }

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

	void DrawBossHeart(int curBossHeart)
	{
		this._txtBossHeart = "Boss Heart: " + this.curBossHeart;
		this.lblBossHeart.text = this._txtBossHeart;
	}

	public void GameClear()
	{
		//this._backSound.Stop();
		//this._gameClear.Play();
		//this.GameClearUI.SetActive(true);

		//this.curLevel += 1;

		switch (curLevel) 
		{
		case 2:
				this.SaveData ();
				SceneManager.LoadScene ("SecondLevel");
				break;
		case 3:
				this.SaveData ();
                	
				SceneManager.LoadScene ("ThirdLevel");
				break;
        

            case 1:	
			default:
				SceneManager.LoadScene ("Main");		
				break;
		}
	}

	public void Die()
	{
		//this._paused = true;		
		//this._backSound.Stop();
		//this._gameover.Play();
		//this.GameoverUI.SetActive(true);
		//this.gameOverScore.text = "Score: " + this.curScore;
		//this.gameOverScore.enabled = true;
		//this.lblBossHeart.enabled = false;

		this.SaveData ();
		SceneManager.LoadScene ("GameOver");
	}
		
	public void SaveData()
	{
		GlobalControl.Instance.Score = this.curScore;
		GlobalControl.Instance.Live = this.curHealth;
		GlobalControl.Instance.Level = this.curLevel;
	}

}
