using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIPlayer : NetworkBehaviour
{
    Attack attack;
    Health health;
    Skills skills;
    //int playerIndex;
    Text attackText;
    Text healthText;
    Button invocationButton;
    Text invocationText;
    bool updateUI = false;

    void Awake()
    {
        attack = GetComponent<Attack>();
        health = GetComponent<Health>();
        skills = GetComponent<Skills>();
    }
    void Update()
    {
        if (updateUI)
        {
            attackText.text = "Attack: " + attack.GetAttackValue();
            healthText.text = "Health: " + health.GetCurrentHealth() + "/" + health.GetMaxHealth();
            invocationText.text = "x" + skills.GetAmountInvocations();
        }
    }
    public void SetUi(int playerIndex)
    {
        attackText = GameObject.Find("AttackPlayer0" + playerIndex).GetComponent<Text>();
        healthText = GameObject.Find("HealthPlayer0" + playerIndex).GetComponent<Text>();
        invocationText = GameObject.Find("InvocationTextPlayer0" + playerIndex).GetComponent<Text>();
        if(isLocalPlayer)
        {
            invocationButton = GameObject.Find("InvocationButtonPlayer0" + playerIndex).GetComponent<Button>();
            invocationButton.onClick.AddListener(skills.InvokeMinion);
        }
        updateUI = true;
    }
}
