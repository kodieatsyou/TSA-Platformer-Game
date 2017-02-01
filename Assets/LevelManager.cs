using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    public GameObject startPoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnTime;

    public GameObject splitPlayer;

    public int currentFollowedNumber = 1;

    public GameObject currentFollow;

    public Camera2DFollow cameraFollow;

    public int numberOfPlayers;

    public string curPlayer;

    public Colors colors;

    public LayerMask ground;

    public List<GameObject> cubeList = new List<GameObject>();

    // Use this for initialization
    void Start() {

        player = FindObjectOfType<PlayerController>();
        colors = FindObjectOfType<Colors>();

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
        if (Input.GetKey(KeyCode.Q))
        {
            currentFollow.GetComponent<PlayerController>().SplitKey();
        }

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        player.transform.position = currentCheckpoint.transform.position;
        player.gameObject.SetActive(true);
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }

    public void Split(Vector3 pos, Quaternion rot, Color col1, Color col2, float sizex, float sizey, int num, LevelManager lm)
    {

        GameObject cube1 = (GameObject)Instantiate(splitPlayer, pos, rot);
        cube1.transform.position = new Vector3(pos.x + 1, pos.y, pos.z);
        cube1.transform.localScale = new Vector3(sizex / 2, sizey / 2, 1);
        cube1.name = "Player " + numberOfPlayers;

        GameObject cube2 = (GameObject)Instantiate(splitPlayer, pos, rot);
        cube2.transform.position = new Vector3(pos.x - 1, pos.y, pos.z);
        cube2.transform.localScale = new Vector3(sizex / 2, sizey / 2, 1);
        numberOfPlayers += 1;
        cube2.name = "Player " + numberOfPlayers;

        MeshRenderer gameObjectRenderer1 = cube1.GetComponent<MeshRenderer>();
        MeshRenderer gameObjectRenderer2 = cube2.GetComponent<MeshRenderer>();

        Material newMaterial1 = new Material(Shader.Find("Standard"));
        Material newMaterial2 = new Material(Shader.Find("Standard"));

        newMaterial1.color = col1;
        newMaterial2.color = col2;
        gameObjectRenderer1.material = newMaterial1;
        gameObjectRenderer2.material = newMaterial2;



        cameraFollow.target = cube1.transform;

        cubeList.Add(cube1);
        cubeList.Add(cube2);

        for (int i = 0; i <= cubeList.Count - 1; i++)
        {
            cubeList[i].GetComponent<PlayerController>().enabled = false;
        }
    }

    public void changeFollowedCubeNigger()
    {
        if (currentFollowedNumber + 1 > cubeList.Count - 1)
        {
            currentFollowedNumber = 0;
        } else
        {
            currentFollowedNumber += 1;
        }

        currentFollow = cubeList[currentFollowedNumber];
        for (int i = 0; i <= cubeList.Count - 1; i++)
        {
            if (cubeList[i] == currentFollow)
            {
                cubeList[i].GetComponent<PlayerController>().enabled = true;
            } else
            {
                cubeList[i].GetComponent<PlayerController>().enabled = false;
            }
        }
        cameraFollow.target = currentFollow.transform;
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
