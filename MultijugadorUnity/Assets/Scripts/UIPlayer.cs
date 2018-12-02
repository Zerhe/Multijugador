using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIPlayer : MonoBehaviour
{
    //int playerIndex;
    Text attackText;
    Text healthText;
    bool updateUI = false;

    void Start()
    {
        //playerIndex = GetComponent<PlayerNetwork>().GetPlayerIndex();
        //print(playerIndex);
        //attackText = GameObject.Find("AttackPlayer0" + playerIndex).GetComponent<Text>();
        //healthText = GameObject.Find("HealthPlayer0" + playerIndex).GetComponent<Text>();
    }
    void Update()
    {
        if (updateUI)
        {
            attackText.text = "Attack: " + GetComponent<Attack>().GetAttackValue();
            healthText.text = "Health: " + GetComponent<Health>().GetCurrentHealth() + "/" + GetComponent<Health>().GetMaxHealth();
        }
    }
    public void SetUi(int playerIndex)
    {
        attackText = GameObject.Find("AttackPlayer0" + playerIndex).GetComponent<Text>();
        healthText = GameObject.Find("HealthPlayer0" + playerIndex).GetComponent<Text>();
        updateUI = true;
    }
}
