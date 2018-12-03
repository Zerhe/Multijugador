using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUpInteraction : NetworkBehaviour
{
    Collider2D coll;

	void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                coll = MouseInput.MouseColission2D();
                if (coll)
                {
                    if (coll.tag == "PowerUp")
                    {
                        //print(1);
                        if (isServer)
                            coll.GetComponent<PowerUp>().PowerUpEffect(this.gameObject);
                        else
                            CmdPowerUpEffect(coll.gameObject);
                    }
                }
            }
        }
    }
    [Command]
    public void CmdPowerUpEffect(GameObject powerUp)
    {
        print(2);
        powerUp.GetComponent<PowerUp>().PowerUpEffect(this.gameObject);

    }
}
