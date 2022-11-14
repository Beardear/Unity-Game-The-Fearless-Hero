using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageDigits : MonoBehaviour
{
    public TMP_Text damageText;
    public float lifeTimer;
    public float upSpeed;
    void Start()
    {
        Destroy(gameObject, lifeTimer);
    }
    void Update()
    {
        transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);//Text Move Up in lifeTimer 
    }
    public void ShowUIDamage(float _amount)
    {
        damageText.text = _amount.ToString();
    }
}
