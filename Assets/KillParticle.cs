using UnityEngine;
using System.Collections;

public class KillParticle : MonoBehaviour {

    private ParticleSystem thisParticle;

	// Use this for initialization
	void Start () {

        thisParticle = GetComponent<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (thisParticle.isPlaying)
            return;

        Destroy(gameObject);
	
	}
}
