using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHeart : MonoBehaviour
{
    public HUD hud;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Beam"))
        {
			
            this.hud.curScore += 250;
            this.hud.curBossHeart -=1;
			Destroy (gameObject);
			Destroy (col.gameObject);

        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Beam"))
		{

			this.hud.curScore += 250;
			this.hud.curBossHeart -=1;
			Destroy (gameObject);
			Destroy (col.gameObject);

		}
	}

   
}