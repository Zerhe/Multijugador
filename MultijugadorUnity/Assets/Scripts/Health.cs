using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private Transform healthBarPivot;
    [SerializeField]
    private bool revive;

    void Start()
    {
        currentHealth = maxHealth;
        if (isLocalPlayer)
        {
            
        }
    }

    /*public void TakeDamage(int amount)
    {
        if (isServer)
        {
            RpcTakeDamage(amount);
        }
    }*/

    [ClientRpc]
    public void RpcTakeDamage(int amount)
    {
        //print(3);
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (revive)
                currentHealth = maxHealth / 5;
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Vector3 vector = healthBarPivot.localScale;
        vector.x = currentHealth / maxHealth;
        healthBarPivot.localScale = vector;
    }
}
