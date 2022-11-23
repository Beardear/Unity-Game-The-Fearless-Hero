using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBorn : MonoBehaviour
{

    //Player
    public GameObject player;

    //该出生点生成的怪物
    public GameObject targetEnemy;
    public GameObject targetDarkKnight;
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

    //第二种怪物的数量
    private int enemyDarkKnightNum = 0;

    void Start()
    {
        //instance = this;
        //初始时，怪物计数为0；
        newEnemyCounter = 0;
        curEnemyCounter = 0;
        enemyDarkKnightNumInit();
        //重复生成怪物
        InvokeRepeating("CreatEnemy", 1F, intervalTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //方法，初始化enemyDarkKnightNum
    private void enemyDarkKnightNumInit()
    {
        Scene scene = SceneManager.GetActiveScene();        //当前场景名称
        switch (scene.name)
        {
            case "StartScene":
                enemyDarkKnightNum = 0;
                break;
            case "Level1":
                enemyDarkKnightNum = 0;
                break;
            case "Level2":
                enemyDarkKnightNum = 1;
                break;
            case "Level3":
                enemyDarkKnightNum = 2;
                break;
            case "Level4":
                enemyDarkKnightNum = 3;
                break;
            case "EndScene":
                enemyDarkKnightNum = 0;
                break;
            default:
                enemyDarkKnightNum = 0;
                break;
        }
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
        if (newEnemyCounter < enemyTotalNum-enemyDarkKnightNum)         //如果基础怪物还没生成够
        {
            Instantiate(targetEnemy, newPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(targetDarkKnight, newPosition, Quaternion.identity);        //如果基础怪物够数了
        }
        

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