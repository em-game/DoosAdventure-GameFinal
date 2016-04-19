using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour {
	

	private GameObject lvl1;
	private GameObject lvl2;
	private GameObject lvl3;



    // Use this for initialization
    void Start () {
		if (Application.loadedLevelName == "Instruction") {
			this.lvl1 = GameObject.FindWithTag ("level1");
			this.lvl2 = GameObject.FindWithTag ("level2");
			this.lvl3 = GameObject.FindWithTag ("level3");
			this.lvl2.gameObject.SetActive (false);
			this.lvl3.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void gameStart()
    {
        SceneManager.LoadScene(2);
    }

	public void Quit()
	{
		Application.Quit ();
	}

	public void Instruction()
	{
		SceneManager.LoadScene (1);
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene (0);
	}

	public void NextTolvl2(){		
		lvl1.gameObject.SetActive (false);
		lvl2.gameObject.SetActive (true);
		lvl3.gameObject.SetActive (false);
	}

	public void NextTolvl3(){
		lvl1.gameObject.SetActive (false);
		lvl2.gameObject.SetActive (false);
		lvl3.gameObject.SetActive (true);
	}
}

