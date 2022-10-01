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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp < 0) return;
        hp -= 20;
        slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void TakeDamge(int damage)//���ܵ��˺�
    {
        if (hp < 0) return;
        hp -= damage;
        slider.value = (float)hp / hpHolder;//ͨ���ı�value��ֵ��float���ͣ����ı�Ѫ�����ȡ�
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}