using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public LevelManager levelManager;

    public Sprite activatedSprite;

    // Use this for initialization
    void Start()
    {

        levelManager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name.Contains("Player"))
        {
            levelManager.currentCheckpoint = gameObject;
            gameObject.GetComponent<SpriteRenderer>().sprite = activatedSprite;
            Debug.Log("Activated Checkpoint " + transform.position);
        }

    }
}
