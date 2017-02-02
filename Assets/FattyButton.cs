using UnityEngine;
using System.Collections;

public class FattyButton : MonoBehaviour {

    public Sprite pushedSprite;

    public Sprite notPushedSprite;

    public LevelManager levelManager;

    public GameObject activator;

    // Use this for initialization
    void Start () {

        levelManager = FindObjectOfType<LevelManager>();

        notPushedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            if (!other.isTrigger)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = pushedSprite;
                activator.GetComponent<Activator>().isActive = true;
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            if (!other.isTrigger)
            {
                return;
            }

        }
    }
}
