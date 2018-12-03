using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
    UIPlayer uiP;
    [SerializeField]
    List<Sprite> sprites;
    [SerializeField]
    SpriteRenderer sR;
    [SyncVar(hook = "ChangeSkin")]
    int playerIndex;

    private void Awake()
    {
        uiP = GetComponent<UIPlayer>();
    }
    private void Start()
    {
        if (!sR.sprite && playerIndex != 0)
        {
            uiP.SetUi(playerIndex);
            sR.sprite = sprites[playerIndex];
            return;
        }
    }
    public override void OnStartLocalPlayer()
    {        
        if (isServer)
        {
            playerIndex = FindObjectsOfType<PlayerNetwork>().Length;
            //uiP.SetUi(playerIndex);
        }
        else
        {
            CmdChangeSkin(FindObjectsOfType<PlayerNetwork>().Length);
        }
    }
    [Command]
    public void CmdChangeSkin(int numPlayer)
    {
        playerIndex = FindObjectsOfType<PlayerNetwork>().Length;
        //uiP.SetUi(playerIndex);
        //RpcChangeSkin(numPlayer);
    }
    public void ChangeSkin(int numPlayer)
    {
        sR.sprite = sprites[numPlayer];
        if (numPlayer == 2)
        {
            sR.transform.rotation = new Quaternion(0, 180, 0, 0);

        }
        uiP.SetUi(numPlayer);
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
}