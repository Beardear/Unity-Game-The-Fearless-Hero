using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text TxtVictory;
    public Text TxtFailure;
    public GameObject Result;
    public GameObject KickIcon;
    public GameObject DiveKickIcon;
    public GameObject JabIcon;
    public GameObject JumpKickIcon;
    public Slider slider;
    public GameObject LvText;
    public Button button;


    public void showResult(bool result)
    {
        if (result == false)
        {
            button.GetComponent<Text>().text="Restart Game";
        }
        TxtVictory.gameObject.SetActive(result);
        TxtFailure.gameObject.SetActive(!result);
    }

    public void onClickClose()
    {
        //gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (PlayerModel.Instance.KungfuEnableList["Kick"])
            KickIcon.SetActive(true);
        if (PlayerModel.Instance.KungfuEnableList["DiveKick"])
            DiveKickIcon.SetActive(true);
        if (PlayerModel.Instance.KungfuEnableList["Jab"])
            JabIcon.SetActive(true);
        if (PlayerModel.Instance.KungfuEnableList["JumpKick"])
            JumpKickIcon.SetActive(true);

        //经验条
        float levelHolder = 100;
        slider.value = (float)(PlayerModel.Instance.LvValue % 100 / levelHolder);
        //print(slider.value);

        //等级
        LvText.GetComponent<Text>().text = "Lv." + PlayerModel.Instance.Lv.ToString();
    }
}
