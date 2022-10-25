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
    public int enemyTotalNum = 3;
    //生成怪物的时间间隔
    public float intervalTime = 5;
    //生成怪物的计数器
    public int newEnemyCounter;
    //场上还活着的怪物的计数器
    public int curEnemyCounter;
    //刷怪结束
    public bool bornFinished = false;

    //生成怪物的计数器
    
    void Start()
    {
        //instance = this;
        //初始时，怪物计数为0；
        newEnemyCounter = 0;
        curEnemyCounter = 0;
        //重复生成怪物
        InvokeRepeating("CreatEnemy", 1F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //方法，生成怪物
    private void CreatEnemy()
    {
        //Random Positions
        //X介于2-8，Y介于-4--1，EnemyBorn.transform.position=(2,-4)
        Vector3 newPosition = this.transform.position;
        newPosition.x += Random.Range(0, 6.0f);
        newPosition.y += Random.Range(0, 3.0f);

        //生成一只怪物
        Instantiate(targetEnemy, newPosition, Quaternion.identity);

        //print("monster rotation" + Quaternion.identity);
        //targetEnemy.GetComponent<Enemy>().target = player.transform;

        newEnemyCounter++;
        curEnemyCounter++;

        //如果计数达到最大值
        if (newEnemyCounter == enemyTotalNum)
        {
            //停止刷新
            bornFinished = true;
            CancelInvoke();
        }
    }
}