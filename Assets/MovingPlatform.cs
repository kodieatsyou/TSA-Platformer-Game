using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public GameObject destination;

    public GameObject start;

    public bool loop;

    public float speed;

    private bool reachDestination;
    private bool reachStart;

    public Activator activator;

	// Use this for initialization
	void Start () {

        activator = FindObjectOfType<Activator>();

        reachStart = true;

        gameObject.transform.position = start.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (activator == null)
            return;

        if (!activator.isActive)
            return;

        if (!loop)
        {
            if ((gameObject.transform.position.x >= destination.transform.position.x) && (gameObject.transform.position.y >= destination.transform.position.y))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                return;
            }
        }

        if ((gameObject.transform.position.x >= destination.transform.position.x) && (gameObject.transform.position.y >= destination.transform.position.y))
        {
            reachDestination = true;
            reachStart = false;
        }

        if ((gameObject.transform.position.x <= start.transform.position.x) && (gameObject.transform.position.y <= start.transform.position.y))
        {
            reachDestination = false;
            reachStart = true;
        }

        if (reachStart)
        {
            for (float i = gameObject.transform.position.x; i <= destination.transform.position.x; i += speed)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }

            for (float i = gameObject.transform.position.y; i <= destination.transform.position.y; i += speed)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
        }

        if (reachDestination)
        {
            for (float i = gameObject.transform.position.x; i >= start.transform.position.x; i -= speed)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            }

            for (float i = gameObject.transform.position.y; i >= start.transform.position.y; i -= speed)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
        }

       

    }
}
