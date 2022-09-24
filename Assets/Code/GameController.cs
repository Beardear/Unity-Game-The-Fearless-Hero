using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    //Outlet
    public GameObject SkeletonClothedPrefab;
    public GameObject Hero;

    //private bool creatingMonster;//ÊÇ·ñ¼ÌÐø²ú¹Ö


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

    }
}
