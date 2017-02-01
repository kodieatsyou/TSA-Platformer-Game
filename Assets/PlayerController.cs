using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public bool doubleJumped;

    public Colors colors;

    public bool canMove;

    public Color objectColor;

    Renderer rend;

    public LevelManager levelManager;

    public bool isBeingUsed;

    private Color[] colorArray;

    public GameObject interactSprite;

    public GameObject mateCube;

    public PlayerInteractable interact;

    public Color combinedColor;

    // Use this for initialization
    void Start () {
        interact = FindObjectOfType<PlayerInteractable>();
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");

        levelManager = FindObjectOfType<LevelManager>();
        colors = FindObjectOfType<Colors>();

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
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    public void SplitKey()
    {
        colorArray = colors.findSplit(objectColor);
        if (colorArray == null)
        {
            return;
        }
        levelManager.Split(gameObject.transform.position, gameObject.transform.rotation, colorArray[0], colorArray[1], gameObject.transform.localScale.x, gameObject.transform.localScale.y, levelManager.numberOfPlayers, levelManager);
        levelManager.cubeList.Remove(gameObject);
        Destroy(gameObject);
    }

    public void StopMoving()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void MateKey()
    {
        if (mateCube == null)
        {
            return;
        }
        Debug.Log(mateCube.name);
        combinedColor = colors.CombineColorsFam(objectColor, mateCube.GetComponent<PlayerController>().objectColor);
        if (combinedColor == Color.magenta)
        {
            return;
        }
        levelManager.Combine(combinedColor, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.localScale.x, mateCube.transform.localScale.x, gameObject.transform.localScale.y, mateCube.transform.localScale.y, gameObject, mateCube.gameObject);
        levelManager.cubeList.Remove(gameObject);
        levelManager.cubeList.Remove(mateCube);
        Destroy(mateCube);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            mateCube = other.gameObject;
            interactSprite.GetComponent<SpriteRenderer>().enabled = !interactSprite.GetComponent<SpriteRenderer>().enabled;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Contains("Player"))
        {
            mateCube = null;
            interactSprite.GetComponent<SpriteRenderer>().enabled = !interactSprite.GetComponent<SpriteRenderer>().enabled;
        }
    }
}
