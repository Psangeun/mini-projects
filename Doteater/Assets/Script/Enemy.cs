using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Player player;
    public GameObject target;
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isEnemyStoped)
        {
            agent.destination = target.transform.position;
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            agent.velocity = Vector3.zero;
            anim.SetFloat("Speed", 0);
        }
    }
}
