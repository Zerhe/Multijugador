using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private Transform healthBarPivot;
    private bool revive = false;
    private bool poison = false;
    private float timerPoison = 0;
    private float timerPoison02 = 0;
    private float amountPosion = 0;
    private float durationPoison = 0;
    private float periodPoison = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (poison)
            Poison();
    }
    [ClientRpc]
    public void RpcTakeDamage(float amount)
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
    //[ClientRpc]
    public void Poison()
    {
        timerPoison += Time.deltaTime;
        timerPoison02 += Time.deltaTime;

        if (timerPoison > durationPoison)
        {
            poison = false;
            timerPoison = 0;
        }
        if(timerPoison02 > periodPoison)
        {
            RpcTakeDamage(amountPosion);
            timerPoison02 = 0;
        }
    }
    public void SetPoison(float aPoison, float dPoison, float pPoison)
    {
        amountPosion = aPoison;
        durationPoison = dPoison;
        periodPoison = pPoison;
        poison = true;
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }
    private void OnDisable()
    {
        GameObject win = new GameObject();
        GameObject lose = new GameObject();

        if(gameObject.tag == "Player")
        {
            foreach(RectTransform rT in Resources.FindObjectsOfTypeAll(typeof(RectTransform)))
            {
                if (rT.gameObject.name == "Win")
                    win = rT.gameObject;
                else if (rT.gameObject.name == "Lose")
                    lose = rT.gameObject;
            }
            if(isLocalPlayer)
            {
                lose.SetActive(true);
            }
            else
                win.SetActive(true);
        }
    }
}
