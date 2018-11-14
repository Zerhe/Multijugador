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
    private bool isDestroyable;
    private Vector3 spawnPoint;
    private NetworkStartPosition[] spawnPoints;


	void Start ()
    {
        currentHealth = maxHealth;
        if(isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
	}

    public void TakeDamage(int amount)
    {
        if (!isServer)//Solo quiero que el server actualice las vidas de los players y despues los sincronice.
        {
            return;
        }

        currentHealth -= amount;
        Vector3 vector= healthBarPivot.localScale;
        vector.x = currentHealth/maxHealth;
        healthBarPivot.localScale = vector;

        if (currentHealth <= 0)
        {
            if (isDestroyable)
                Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }

        }
        //El hook se llama al actualizarse incluso en el server, asi que esta linea está de más
        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    /*void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }*/

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)//solo la instancia original tiene autoridad de modificar su transform.
        {
            if(spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }
    }
}
