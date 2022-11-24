using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    //Outlet
    //public GameObject SkeletonClothedPrefab;
    //public GameObject Hero;
    //public GameObject enemyBorn;
    //public GameObject Book;


    //Methods
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject newSkeletonClothed = Instantiate(SkeletonClothedPrefab);
        //newSkeletonClothed.transform.position = new Vector3(5, -3);
    }

    // Update is called once per frame
    void Update()
    {
        //if (InstanceManager.Instance.enemyBorn.curEnemyCounter <= 0 && InstanceManager.Instance.enemyBorn.bornFinished == true)
        //{
        //    showResult(true);
        //}
        if (PlayerController.instance.hp <= 0)
        {
            //²¥·ÅPlayerËÀÍö¶¯»­
            PlayerController.instance.PlayerDeath();
            showResult(false);
        }

    }

    public void showResult(bool result)
    {
        //InstanceManager.Instance.resultUI.gameObject.SetActive(true);
        InstanceManager.Instance.uI.Result.SetActive(true);
        InstanceManager.Instance.uI.showResult(result);
    }
}
