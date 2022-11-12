using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        Scene scene = SceneManager.GetActiveScene();        //当前场景名称
        string nextSceneName;

        switch (scene.name)
        {
            case "StartScene":
                nextSceneName = "Level1";
                break;
            case "Level1":
                nextSceneName = "Level2";
                break;
            case "Level2":
                nextSceneName = "Level3";
                break;
            case "Level3":
                nextSceneName = "Level4";
                break;
            case "Level4":
                nextSceneName = "EndScene";
                break;
            case "EndScene":
                nextSceneName = "StartScene";
                break;
            default:
                nextSceneName = "StartScene";
                break;
        }

        if (nextSceneName == "StartScene")
        {
            PlayerModel.Instance.KungfuEnableList["Kick"] = true;
            PlayerModel.Instance.KungfuEnableList["DiveKick"] = false;
        }

        SceneManager.LoadScene(nextSceneName);        //切换场景
    }

    // Update is called once per frame
    void Update()
    {

    }
}