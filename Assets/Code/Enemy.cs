using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;

    //Outlet
    private NavMeshAgent agent;
    public Slider slider;

    private int hp = 100;
    private int hpHolder;
    //Configuration
    //public Transform target;

    //Methods
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        hpHolder = hp;

    }
    void Update()
    {
        agent.SetDestination(target.position);

    }

    private void OnCollisionEnter2D(Collision2D collision)                          //Bug1: Collision with Player may attack; Bug2: Weapon position is not true, is the player pushdown 'A'
    {
        if (hp <= 0) return;
        hp -= 20;
        slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
        if (hp <= 0)
        {
            EnemyBorn.instance.curEnemyCounter--;
            Destroy(this.gameObject);
        }
    }

    //public void TakeDamge(int damage)//当受到伤害
    //{
    //    if (hp < 0) return;
    //    hp -= damage;
    //    slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
    //    if (hp <= 0)
    //    {
    //        EnemyBorn.instance.curEnemyCounter--;
    //        Destroy(this.gameObject);
    //    }
    //}
}