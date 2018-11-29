using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float yKiller;
    [SerializeField]
    private int numTypesPowerUp;
    [SerializeField]
    private List<Sprite> sprites;
    private int type;
    [SerializeField]
    private int amountLifeRecovery;
    [SerializeField]
    private int amountDamageIncrease;

	void Start ()
    {
        type = Random.Range(0, numTypesPowerUp);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < yKiller)
            Destroy(gameObject);
	}

    //[ClientRpc]
    public void PowerUpEffect(GameObject player)
    {
        Destroy(gameObject);
        switch (type)
        {
            case 0:
                player.GetComponent<Health>().RpcTakeDamage(-amountLifeRecovery);
                break;
            case 1:
                player.GetComponent<Attack>().SetAttack(amountDamageIncrease);
                break;
            default:
                break;
        }
    }
}
