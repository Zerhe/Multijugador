using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Minion : NetworkBehaviour
{
    Animator animator;
    GameObject enemyCollision;
    [SerializeField]
    float velMovInitial;
    float velMov;
    [SerializeField]
    float amountAttack;
    float timerAttack;
    [SerializeField]
    float timeAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        velMov = velMovInitial;
        animator.SetTrigger("walk");
    }	
	void Update ()
    {
        transform.Translate(Vector3.right * Time.deltaTime * velMov);
        if (enemyCollision && !enemyCollision.activeInHierarchy)
        {
            velMov = velMovInitial;
            animator.ResetTrigger("skill_1");
            animator.SetTrigger("walk");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Minion")
        {
            enemyCollision = collision.gameObject;
            velMov = 0;
            animator.ResetTrigger("walk");
            animator.SetTrigger("skill_1");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isServer && collision.gameObject.tag == "Player" || collision.gameObject.tag == "Minion")
        {
            timerAttack += Time.deltaTime;
            if(timerAttack > timeAttack)
            {
                print("ahhhhh");
                collision.gameObject.GetComponent<Health>().RpcTakeDamage(amountAttack);
                timerAttack = 0;                
            }
        }
    }
}
