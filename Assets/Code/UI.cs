using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text TxtVictory;
    public Text TxtFailure;
    public GameObject Result;
    public GameObject KickIcon;
    public GameObject Dive_KickIcon;

    

    public void showResult(bool result)
    {
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
            Dive_KickIcon.SetActive(true);

    }
}
