using UnityEngine;
using System.Collections;

public class Interactabe : MonoBehaviour {

    public GameObject interactSprite;

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        interactSprite.GetComponent<SpriteRenderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == levelManager.currentFollow.name)
        {
            interactSprite.GetComponent<SpriteRenderer>().enabled = !interactSprite.GetComponent<SpriteRenderer>().enabled;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            interactSprite.GetComponent<SpriteRenderer>().enabled = !interactSprite.GetComponent<SpriteRenderer>().enabled;
        }
    }
    
}
