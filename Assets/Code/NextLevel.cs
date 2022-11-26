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
        if (SceneManager.GetActiveScene().name=="EndScene")
        {
            PlayerModel.Instance.KungfuEnableList["Kick"] = false;
            PlayerModel.Instance.KungfuEnableList["DiveKick"] = false;
            PlayerModel.Instance.KungfuEnableList["JumpKick"] = false;
            PlayerModel.Instance.LvValue = 0;
            PlayerModel.Instance.Lv = 1;

            SceneManager.LoadScene("StartScene");               //如果是EndScene就重新加载
            return;
        }
        
        if (SceneManager.GetActiveScene().name=="StartScene")
        {
            SceneManager.LoadScene("Level1");               //如果是StartScene就加载第一关
            return;
        }
        
        //如果是LevelScene就需要看按钮文本
        if (InstanceManager.Instance.uI.button.GetComponent<Text>().text=="Next Level")     //如果按钮文本上是Next Level
        {
            Scene scene = SceneManager.GetActiveScene();        //当前场景名称
            string nextSceneName;

            switch (scene.name)
            {
                //case "StartScene":
                //    nextSceneName = "Level1";
                //    break;
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
                //case "EndScene":
                //    nextSceneName = "StartScene";
                //    break;
                default:
                    nextSceneName = "StartScene";
                    break;
            }

            if (nextSceneName == "StartScene")
            {
                PlayerModel.Instance.KungfuEnableList["Kick"] = false;
                PlayerModel.Instance.KungfuEnableList["DiveKick"] = false;
                PlayerModel.Instance.KungfuEnableList["JumpKick"] = false;
                PlayerModel.Instance.LvValue = 0;
                PlayerModel.Instance.Lv = 1;
            }

            SceneManager.LoadScene(nextSceneName);        //切换场景
        }
        else
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);                 //如果文本是RestartGame

            PlayerModel.Instance.KungfuEnableList["Kick"] = false;
            PlayerModel.Instance.KungfuEnableList["DiveKick"] = false;
            PlayerModel.Instance.KungfuEnableList["JumpKick"] = false;
            PlayerModel.Instance.LvValue = 0;
            PlayerModel.Instance.Lv = 1;

            SceneManager.LoadScene("StartScene");                 //如果文本是RestartGame
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}