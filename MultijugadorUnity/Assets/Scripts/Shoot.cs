using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shoot : NetworkBehaviour
{

    [SerializeField]
    private GameObject bulletObject;
    [SerializeField]
    private Transform spawnBullet;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                CmdFire();
            }
        }
    }
    [Command]
    public void CmdFire()
    {
        GameObject bullet = Instantiate(bulletObject, spawnBullet.position, spawnBullet.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2);
    }
}
