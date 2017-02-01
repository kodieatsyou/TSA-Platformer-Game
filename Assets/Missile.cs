using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public float missileSpeed;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(missileSpeed, GetComponent<Rigidbody2D>().velocity.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Destroy(gameObject);
    }
}
