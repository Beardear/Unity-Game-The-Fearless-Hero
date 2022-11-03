using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public GameController gameController;
    public UI uI;
    public EnemyBorn enemyBorn;
    public PlayerController PlayerController;
    public SoundManager soundManager;

    public static InstanceManager Instance;
    // Start is called before the first frame update
     void Awake()
    {
        Instance = this;
    }
}
