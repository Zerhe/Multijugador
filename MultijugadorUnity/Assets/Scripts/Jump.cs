using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Jump : NetworkBehaviour
{
    Collider2D coll;
    [SerializeField]
    float velJump;
    [SerializeField]
    float heightJump;
    float timerJump;
    bool jump;
    [SerializeField]
    int maxJumps;
    int amountJumps;

    private void Start()
    {
        amountJumps = maxJumps;
    }
    void Update ()
    {
        if (isLocalPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
                coll = MouseInput.MouseColission2D();
                if (coll)
                {
                    if (coll.gameObject == this.gameObject && !jump && amountJumps > 0)
                    {
                        jump = true;
                        amountJumps--;
                    }
                }
            }
        }
        if(jump)
        {
            timerJump += Time.deltaTime;
            transform.Translate(Vector3.up * Time.deltaTime * velJump);
        }
        if (timerJump > heightJump)
        {
            timerJump = 0;
            jump = false;
        }
        if(transform.position.y > -0.6 && !jump)
            transform.Translate(-Vector3.up * Time.deltaTime * velJump);
        if (transform.position.y < -0.6)
            amountJumps = maxJumps;
    }
    [Command]
    public void CmdJump()
    {
        RpcJump();
    }
    [ClientRpc]
    public void RpcJump()
    {
        
    }
}
