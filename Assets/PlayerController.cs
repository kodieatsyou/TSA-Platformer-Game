using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    public Colors colors;

    public bool canMove;

    public Color objectColor;

    Renderer rend;

    public LevelManager levelManager;

    Color startColor;

    private Color[] colorArray;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");

        levelManager = FindObjectOfType<LevelManager>();
        colors = FindObjectOfType<Colors>();

        startColor = colors.white;

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {

        if (!canMove)
        {
            return;
        }

        if (grounded)
            doubleJumped = false;

    }

    public void moveLeft()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void moveRight()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void jump()
    {
        if (grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        if(!doubleJumped && !grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJumped = true;
        }
    }

    public void SplitKey()
    {
        colorArray = colors.findSplit(startColor);
        levelManager.Split(gameObject.transform.position, gameObject.transform.rotation, colorArray[0], colorArray[1], gameObject.transform.localScale.x, gameObject.transform.localScale.y, levelManager.numberOfPlayers, levelManager);
        Destroy(gameObject);
    }

    public void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }
}
