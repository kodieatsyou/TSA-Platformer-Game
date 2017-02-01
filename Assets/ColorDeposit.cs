using UnityEngine;
using System.Collections;

public class ColorDeposit : MonoBehaviour {

    public GameObject activator;
    public string colorName;
    public Color color;
    public LevelManager levelManager;

    Colors colors;

    private bool ready;

	// Use this for initialization
	void Start () {

        colors = FindObjectOfType<Colors>();

        color = colors.findColor(colorName);

        levelManager = FindObjectOfType<LevelManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ready && Input.GetKeyDown(KeyCode.E))
        {
            if (levelManager.currentFollow.GetComponent<PlayerController>().objectColor == colors.colorDictionary[colorName])
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
