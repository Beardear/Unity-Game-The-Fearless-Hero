using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public GameController gameController;

    public static InstanceManager Instance;
    // Start is called before the first frame update
     void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
