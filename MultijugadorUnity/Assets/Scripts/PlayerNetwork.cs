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
    [SyncVar(hook = "ChangeSkin")]
    int spriteIndex;

    private void Start()
    {
        if (!sR.sprite)
        {
            print(spriteIndex);
            sR.sprite = sprites[spriteIndex];
            return;
        }
    }
    void Update()
    {
        
    }
    public override void OnStartLocalPlayer()
    {
        /*if (FindObjectsOfType<PlayerNetwork>().Length == 1)
        {
            RpcChangeSkin(0);
        }
        else if (FindObjectsOfType<PlayerNetwork>().Length == 2)
        {
            CmdChangeSkin(1);
        }*/
        /*if (isServer)
        {
            print("asdassda");
            RpcChangeSkin(FindObjectsOfType<PlayerNetwork>().Length);
        }
        else
            CmdChangeSkin(FindObjectsOfType<PlayerNetwork>().Length);*/
        if (isServer)
            spriteIndex = FindObjectsOfType<PlayerNetwork>().Length;
        else
            CmdChangeSkin(FindObjectsOfType<PlayerNetwork>().Length);

    }
    [Command]
    public void CmdChangeSkin(int numPlayer)
    {
        print(numPlayer);
        spriteIndex = FindObjectsOfType<PlayerNetwork>().Length;
        //RpcChangeSkin(numPlayer);
    }
    public void ChangeSkin(int numPlayer)
    {
        print(isServer);
        sR.sprite = sprites[numPlayer];
        if (numPlayer == 2)
            sR.flipX = false;
    }
}