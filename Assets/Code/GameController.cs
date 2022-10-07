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
        if (EnemyBorn.instance.curEnemyCounter <= 0 && EnemyBorn.instance.bornFinished == true)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            showResult(true);
        }
        if (PlayerController.instance.hp<=0)
        {
            showResult(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void showResult(bool result)
    {
        InstanceManager.Instance.resultUI.gameObject.SetActive(true);
        InstanceManager.Instance.resultUI.showResult(result);
    }
}
