using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBorn : MonoBehaviour
{
    //Player
    public GameObject player;

    //该出生点生成的怪物
    public GameObject targetEnemy;
    //生成怪物的总数量
    public int enemyTotalNum = 10;
    //生成怪物的时间间隔
    public float intervalTime = 3;
    //生成怪物的计数器
    private int enemyCounter;

    //生成怪物的计数器

    // Use this for initialization
    void Start()
    {
        //初始时，怪物计数为0；
        enemyCounter = 0;
        //重复生成怪物
        InvokeRepeating("CreatEnemy", 0.5F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //方法，生成怪物
    private void CreatEnemy()
    {
        //Random Positions
        //X介于2-10，Y介于-4--1，EnemyBorn.transform.position=(2,-4)
        Vector3 newPosition = this.transform.position;
        newPosition.x += Random.Range(0, 8.0f);
        newPosition.y += Random.Range(0, 3.0f);

        //生成一只怪物
        Instantiate(targetEnemy, newPosition, Quaternion.identity);
        targetEnemy.GetComponent<Enemy>().target = player.transform;
        enemyCounter++;
        //如果计数达到最大值
        if (enemyCounter == enemyTotalNum)
        {
            //停止刷新
            CancelInvoke();
        }
    }
}