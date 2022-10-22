using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //Outlet
    Rigidbody2D _rigidbody2D;
    SpriteRenderer sprite;
    Animator animator;

    public Slider slider;

    /// <summary>
    /// 左边攻击碰撞体
    /// </summary>
    public GameObject LeftWeapon;
    /// <summary>
    /// 右边攻击碰撞体
    /// </summary>
    public GameObject RightWeapon;

    public int hp = 100;
    private int hpHolder;
    private float speedUpArgument;

    //KungfuEnableList
    public Dictionary<string,bool> KungfuEnableList;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        hpHolder = hp;
        speedUpArgument = 1;        //默认不加速

        // 主角默认向右
        setDirection(false);

        //KungfuEnableList
        KungfuEnableList = new Dictionary<string,bool>();
        KungfuEnableList.Add("Kick", true);
        KungfuEnableList.Add("DiveKick", false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);


        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += new Vector3(0, 0.1f, 0);
            _rigidbody2D.AddForce(Vector2.up * 25f * Time.deltaTime* speedUpArgument, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += new Vector3(0, -0.1f, 0);
            _rigidbody2D.AddForce(Vector2.down * 25f * Time.deltaTime* speedUpArgument, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(-0.1f, 0, 0);
            _rigidbody2D.AddForce(Vector2.left * 36f * Time.deltaTime* speedUpArgument, ForceMode2D.Impulse);
            sprite.flipX = true;
            setDirection(true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(0.1f, 0, 0);
            _rigidbody2D.AddForce(Vector2.right * 36f * Time.deltaTime* speedUpArgument, ForceMode2D.Impulse);
            sprite.flipX = false;
            setDirection(false);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))    //Shift speed up
        {
            speedUpArgument = 1.8f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))    //Shift speed up
        {
            speedUpArgument = 1f;
        }

        //Attack
        if (Input.GetMouseButtonDown(0)&&KungfuEnableList["Kick"])
        {
            //_rigidbody2D.velocity.Set(0,0);
            //animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

            animator.SetTrigger("Kick");
        }
        if (Input.GetKeyUp(KeyCode.K) && KungfuEnableList["DiveKick"])
        {
            //_rigidbody2D.velocity.Set(0,0);
            //animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

            animator.SetTrigger("DiveKick");
        }

    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("player tag:" + collision.collider.tag);
        //怪物武器攻击才会对主角产生伤害
        if (collision.collider.tag != "MonsterWeapon")
        {
            return;
        }
        collision.collider.enabled = false;
        if (hp < 0) return;
        hp -= 5;
        slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
        //if (hp <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
    }

    //public void TakeDamge(int damage)//当受到伤害
    //{
    //    if (hp < 0) return;
    //    hp -= damage;
    //    slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
    //    //if (hp <= 0)
    //    //{
    //    //    Destroy(this.gameObject);
    //    //}
    //}

    /// <summary>
    /// 跟随主角方向显示对应攻击碰撞体
    /// </summary>
    /// <param name="value"></param>
    private void setDirection(bool value)
    {
        LeftWeapon.SetActive(value);
        RightWeapon.SetActive(!value);
    }
}