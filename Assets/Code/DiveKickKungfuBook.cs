using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveKickKungfuBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Player")
        {
            return;
        }
        //InstanceManager.Instance.PlayerController.KungfuEnableList["DiveKick"] = true;
        PlayerModel.Instance.KungfuEnableList["DiveKick"] = true;
        Destroy(this.gameObject);
    }
}
