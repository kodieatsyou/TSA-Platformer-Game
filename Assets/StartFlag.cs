using UnityEngine;
using System.Collections;

public class StartFlag : MonoBehaviour {

    public LevelManager levelManager;

    // Use this for initialization
    void Start () {

        levelManager = FindObjectOfType<LevelManager>();

        levelManager.currentCheckpoint = gameObject;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
