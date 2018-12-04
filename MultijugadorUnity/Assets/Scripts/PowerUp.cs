using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUp : NetworkBehaviour
{
    private PlayerNetwork[] players;
    private SpriteRenderer sR;
    [SerializeField]
    private float yKiller;
    [SerializeField]
    private float velMov;
    [SerializeField]
    private int numTypesPowerUp;
    [SerializeField]
    private List<Sprite> sprites;
    private int type;
    [SerializeField]
    private int amountLifeRecovery;
    [SerializeField]
    private int amountDamageIncrease;
    [SerializeField]
    private float amountPoison;
    [SerializeField]
    private float durationPoison;
    [SerializeField]
    private float periodPoison;
    [SerializeField]
    private int amountInvocations;
    [SerializeField]
    private float spikeDamage;

    private void Awake()
    {
        sR = GetComponent<SpriteRenderer>();       
    }
    void Start ()
    {
        if(isServer)
        {
            type = Random.Range(0, numTypesPowerUp);
            RpcSetType(type);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * Time.deltaTime * velMov);
        if (transform.position.y < yKiller)
            Destroy(gameObject);
	}

    [ClientRpc]
    public void RpcSetType(int t)
    {
        //print(t);
        sR.sprite = sprites[t];
    }
    public void PowerUpEffect(GameObject player)
    {
        Destroy(gameObject);
        switch (type)
        {
            case 0:
                player.GetComponent<Health>().RpcTakeDamage(-amountLifeRecovery);
                break;
            case 1:
                player.GetComponent<Attack>().RpcSetAttack(amountDamageIncrease);
                break;
            case 2:
                players = FindObjectsOfType<PlayerNetwork>();
                players[Random.Range(0, 2)].GetComponent<Health>().SetPoison(amountPoison, durationPoison, periodPoison);
                break;
            case 3:
                player.GetComponent<Skills>().RpcIncreaseAmountInvocations(amountInvocations);
                break;
            case 4:
                player.GetComponent<Health>().RpcTakeDamage(spikeDamage);
                break;
            default:
                break;
        }
    }
}
