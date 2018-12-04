using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Attack : NetworkBehaviour
{
    Collider2D coll;
    [SerializeField]
    float attackValue;

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
                    if (coll.gameObject != this.gameObject && coll.tag == this.tag || coll.tag == "Minion")
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
    public void CmdTakeDamage(GameObject gameObject, float attackValue)
    {
        //print(2);
        gameObject.GetComponent<Health>().RpcTakeDamage(attackValue);
    }
    [ClientRpc]
    public void RpcSetAttack(int newAttackValue)
    {
        attackValue += newAttackValue;
    }
    public float GetAttackValue()
    {
        return attackValue;
    }
}
