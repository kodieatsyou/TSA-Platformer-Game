using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float distance;
    void Update()
    {

        transform.position = new Vector3(player.position.x, player.position.y, distance);

    }
}