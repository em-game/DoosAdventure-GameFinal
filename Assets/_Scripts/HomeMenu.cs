using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
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
}

