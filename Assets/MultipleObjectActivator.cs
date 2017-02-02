using UnityEngine;
using System.Collections;

public class MultipleObjectActivator : MonoBehaviour {

    public GameObject objectBeingActivated;

    public LevelManager levelManager;

    private bool active;

	// Use this for initialization
	void Start () {

        levelManager = FindObjectOfType<LevelManager>();

        active = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        objectBeingActivated.SetActive(active);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            if (!other.isTrigger)
            {
                active = !active;
            }

        }

    }
}
