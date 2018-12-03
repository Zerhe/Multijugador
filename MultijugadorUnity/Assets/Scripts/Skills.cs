using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Skills : NetworkBehaviour
{
    [SerializeField]
    GameObject minion;
    [SerializeField]
    Transform spawnMinion;
    int amountInvocations;

    public void InvokeMinion()
    {
        CmdInvokeMinion();
    }
    [Command]
    public void CmdInvokeMinion()
    {
        print("acaLLego");
        if(amountInvocations > 0)
        {
            print("YoteINvoko");
            GameObject obj = Instantiate(minion, spawnMinion.position, spawnMinion.rotation);
            NetworkServer.Spawn(obj);
            RpcIncreaseAmountInvocations(-1);
        }
    }
    [ClientRpc]
    public void RpcIncreaseAmountInvocations(int amount)
    {
        amountInvocations += amount;
    }
    public int GetAmountInvocations()
    {
        return amountInvocations;
    }
}
