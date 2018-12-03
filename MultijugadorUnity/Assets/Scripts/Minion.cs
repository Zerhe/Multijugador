using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Minion : NetworkBehaviour
{
    Animator animator;
    [SerializeField]
    float velMov;
    [SerializeField]
    float amountAttack;
    float timerAttack;
    [SerializeField]
    float timeAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }	
	void Update ()
    {
        transform.Translate(Vector3.right * Time.deltaTime * velMov);
        animator.SetTrigger("walk");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("ayy");
        if(collision.gameObject.tag == "Player")
        {
            velMov = 0;
            animator.ResetTrigger("walk");
            animator.SetTrigger("skill_1");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isServer && collision.gameObject.tag == "Player")
        {
            timerAttack += Time.deltaTime;
            if(timerAttack > timeAttack)
            {
                //print("ahhhhh");
                collision.gameObject.GetComponent<Health>().RpcTakeDamage(amountAttack);
                timerAttack = 0;
            }
        }
    }
}
