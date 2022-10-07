using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{

    public Text TxtVictory;
    public Text TxtFailure;

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
}
