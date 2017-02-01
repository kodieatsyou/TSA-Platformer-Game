using UnityEngine;
using System.Collections;

public class PlayerArrow : MonoBehaviour {

    private Animator anim;

    public LevelManager levelManager;

	// Use this for initialization
	void Start () {

        levelManager = FindObjectOfType<LevelManager>();
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetBool("isRunning", true);

        transform.position = new Vector3(levelManager.currentFollow.transform.position.x, levelManager.currentFollow.transform.position.y + 1, levelManager.currentFollow.transform.position.z);
	
	}
}
