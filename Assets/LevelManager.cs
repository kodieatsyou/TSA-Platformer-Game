using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    public GameObject startPoint;

    private PlayerController initPlayer;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnTime;

    public GameObject splitPlayer;

    public int currentFollowedNumber = 0;

    public GameObject currentFollow;

    public Camera2DFollow cameraFollow;

    public int numberOfPlayers;

    public string curPlayer;

    public Colors colors;

    public LayerMask ground;

    private bool canSwitchPlayers;

    public PhysicsMaterial2D unusedPlayer;

    public PhysicsMaterial2D usedPlayer;

    public List<GameObject> cubeList = new List<GameObject>();

    // Use this for initialization
    void Start() {

        canSwitchPlayers = true;

        initPlayer = FindObjectOfType<PlayerController>();
        initPlayer.objectColor = Color.white;
        colors = FindObjectOfType<Colors>();

        Debug.Log("player.objectColor");

        cameraFollow = FindObjectOfType<Camera2DFollow>();

        curPlayer = "Player" + numberOfPlayers;


    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeFollowedCubeNigger();
        }

        currentFollow.GetComponent<PlayerController>().StopMoving();

        if (Input.GetKey(KeyCode.A))
        {
            currentFollow.GetComponent<PlayerController>().moveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            currentFollow.GetComponent<PlayerController>().moveRight();
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentFollow.GetComponent<PlayerController>().jump();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentFollow.GetComponent<PlayerController>().SplitKey();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentFollow.GetComponent<PlayerController>().MateKey();
        }

        if (currentFollowedNumber > cubeList.Count - 1)
        {
            currentFollowedNumber = 0;
        }

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        canSwitchPlayers = false;
        Instantiate(deathParticle, currentFollow.transform.position, currentFollow.transform.rotation);
        currentFollow.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        currentFollow.transform.position = currentCheckpoint.transform.position;
        currentFollow.gameObject.SetActive(true);
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        canSwitchPlayers = true;
    }

    public void Split(Vector3 pos, Quaternion rot, Color col1, Color col2, float sizex, float sizey, int num, LevelManager lm)
    {

        GameObject cube1 = (GameObject)Instantiate(splitPlayer, pos, rot);
        cube1.transform.position = new Vector3(pos.x + 1, pos.y, pos.z);
        cube1.transform.localScale = new Vector3(sizex / 2, sizey / 2, 1);
        cube1.name = "Player " + numberOfPlayers;
        cube1.GetComponent<PlayerController>().objectColor = col1;
        cameraFollow.target = cube1.transform;
        currentFollow = cube1;

        GameObject cube2 = (GameObject)Instantiate(splitPlayer, pos, rot);
        cube2.transform.position = new Vector3(pos.x - 1, pos.y, pos.z);
        cube2.transform.localScale = new Vector3(sizex / 2, sizey / 2, 1);
        numberOfPlayers += 1;
        cube2.name = "Player " + numberOfPlayers;
        cube2.GetComponent<PlayerController>().objectColor = col2;

        MeshRenderer gameObjectRenderer1 = cube1.GetComponent<MeshRenderer>();
        MeshRenderer gameObjectRenderer2 = cube2.GetComponent<MeshRenderer>();

        Material newMaterial1 = new Material(Shader.Find("Standard"));
        Material newMaterial2 = new Material(Shader.Find("Standard"));

        newMaterial1.color = col1;
        newMaterial2.color = col2;
        gameObjectRenderer1.material = newMaterial1;
        gameObjectRenderer2.material = newMaterial2;

        cubeList.Add(cube1);
        cubeList.Add(cube2);

        for (int i = 0; i <= cubeList.Count - 1; i++)
        {
            cubeList[i].GetComponent<PlayerController>().enabled = false;
            cubeList[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        currentFollow.GetComponent<PlayerController>().enabled = true;
        currentFollow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        currentFollow.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Combine(Color col, Vector3 pos, Quaternion rot, float sizex1, float sizex2, float sizey1, float sizey2, GameObject obj1, GameObject obj2)
    {
        GameObject cube1 = (GameObject)Instantiate(splitPlayer, pos, rot);
        cube1.transform.localScale = new Vector3(sizex1 + sizex2, sizey1 + sizey2);
        cube1.name = "Player " + numberOfPlayers;
        cube1.GetComponent<PlayerController>().objectColor = col;
        MeshRenderer gameObjectRenderer1 = cube1.GetComponent<MeshRenderer>();
        Material newMaterial1 = new Material(Shader.Find("Standard"));
        newMaterial1.color = col;
        gameObjectRenderer1.material = newMaterial1;
        cubeList.Add(cube1);
        cameraFollow.target = cube1.transform;
        currentFollow = cube1;
    }

    public void changeFollowedCubeNigger()
    {
        if (!canSwitchPlayers)
            return;
        cubeList[currentFollowedNumber].GetComponent<PlayerController>().enabled = false;
        cubeList[currentFollowedNumber].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        if (currentFollowedNumber + 1 > cubeList.Count - 1)
        {
            currentFollowedNumber = 0;
        } else
        {
            currentFollowedNumber += 1;
        }
        currentFollow = cubeList[currentFollowedNumber];
        cubeList[currentFollowedNumber].GetComponent<PlayerController>().enabled = true;
        cubeList[currentFollowedNumber].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        cubeList[currentFollowedNumber].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        cameraFollow.target = cubeList[currentFollowedNumber].transform;
    }

    public void SetParent(GameObject newParent, GameObject child)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        child.transform.parent = newParent.transform;

        //Display the parent's name in the console.
        Debug.Log("Player's Parent: " + child.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + child.transform.parent.parent.name);
        }
    }
}
