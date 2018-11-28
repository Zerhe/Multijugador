using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField]
    List<Sprite> sprites;
    [SerializeField]
    SpriteRenderer sR;

    private void Awake()
    {

    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }
    public override void OnStartLocalPlayer()
    {
        if (FindObjectsOfType<PlayerNetwork>().Length > 1)
        {
            CmdChangeSkin();
        }
    }
    [Command]
    public void CmdChangeSkin()
    {
        if(isServer)
            RpcChangeSkin();
    }
    [ClientRpc]
    public void RpcChangeSkin()
    {
        sR.sprite = sprites[1];
        sR.flipX = false;
    }
}