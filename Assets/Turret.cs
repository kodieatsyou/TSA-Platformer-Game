using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

    public Transform firePoint;
    public GameObject leftMissile;
    public GameObject rightMissile;

    public float fireRate;

	// Use this for initialization
	void Start () {
        StartCoroutine("ShootMissile");
    }
	
	// Update is called once per frame
	void Update () {


	
	}

    private IEnumerator ShootMissile()
    {
        yield return new WaitForSeconds(fireRate);
        Debug.Log("Shooting");
        if (gameObject.transform.localScale.x < 0 )
        {
            Instantiate(rightMissile, firePoint.position, firePoint.rotation);
        } else
        {
            Instantiate(leftMissile, firePoint.position, firePoint.rotation);
        }
 
        StartCoroutine("ShootMissile");
    }

    public void shootProjectile()
    {

    }
}
