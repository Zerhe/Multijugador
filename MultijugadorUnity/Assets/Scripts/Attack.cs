using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Attack : NetworkBehaviour
{
    Collider2D coll;
    [SerializeField]
    int attackValue;

    void Start()
    {
        coll = new Collider2D();
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                coll = MouseInput.MouseColission2D();
                if (coll)
                {
                    if (coll.gameObject != this.gameObject && coll.tag == this.tag)
                    {
                        //print(1);
                        if (isServer)
                            coll.GetComponent<Health>().RpcTakeDamage(attackValue);
                        else
                            CmdTakeDamage(coll.gameObject, attackValue);
                    }
                }
            }
        }
    }
    [Command]
    public void CmdTakeDamage(GameObject gameObject, int attackValue)
    {
        //print(2);
        gameObject.GetComponent<Health>().RpcTakeDamage(attackValue);
    }
    public void SetAttack(int newAttackValue)
    {
        attackValue += newAttackValue;
    }
}
