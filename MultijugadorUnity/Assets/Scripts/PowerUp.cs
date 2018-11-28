using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUp : MonoBehaviour {
    [SerializeField]
    private float yKiller;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < yKiller)
            Destroy(gameObject);
	}

    //[ClientRpc]
    public void PowerUpEffect(GameObject player)
    {
        Destroy(gameObject);
        player.GetComponent<Health>().RpcTakeDamage(-200);
    }
}
