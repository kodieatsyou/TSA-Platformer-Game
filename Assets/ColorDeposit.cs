using UnityEngine;
using System.Collections;

public class ColorDeposit : MonoBehaviour {

    public GameObject activator;
    public Color color;
    public LevelManager levelManager;

    public float r;
    public float g;
    public float b;

    Colors colors;

    private bool ready;

	// Use this for initialization
	void Start () {

        color = new Color(r, g, b);

        gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);

        levelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ready && Input.GetKeyDown(KeyCode.E))
        {
            if (levelManager.currentFollow.GetComponent<PlayerController>().objectColor == color)
            {
                Debug.Log("hi");
                activator.GetComponent<Activator>().isActive = true;
                return;
            }
            return;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            ready = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == levelManager.currentFollow.name)
        {
            ready = false;
        }
    }
}
