using UnityEngine;
using System.Collections;

public class ColorWall : MonoBehaviour {

    public Color color;
    public float r;
    public float g;
    public float b;
    public LevelManager levelManager;

    // Use this for initialization
    void Start () {
        color = new Color(r, g, b);

        levelManager = FindObjectOfType<LevelManager>();

        MeshRenderer wallRend = gameObject.GetComponent<MeshRenderer>();

        Material newMaterial1 = new Material(Shader.Find("Standard"));

        newMaterial1.color = color;
        wallRend.material = newMaterial1;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (levelManager.currentFollow.GetComponent<PlayerController>().objectColor == color)
        {
            Destroy(gameObject);
            return;
        }
    }
}
