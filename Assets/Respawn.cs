using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public LevelManager levelManager;

    public Sprite activatedSprite;

    public GameObject activateParticle;

    public bool activated;

    // Use this for initialization
    void Start()
    {

        levelManager = FindObjectOfType<LevelManager>();
        activated = false;

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name.Contains("Player"))
        {
            if (!activated)
            {
                levelManager.currentCheckpoint = gameObject;
                gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
                Instantiate(activateParticle, gameObject.transform.position, gameObject.transform.rotation);
                Debug.Log("Activated Checkpoint " + transform.position);
                activated = true;
            }

        }

    }
}
