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
    public GameObject KickLeftWeapon;
    public GameObject DiveKickLeftWeapon;
    public GameObject JabLeftWeapon;
    public GameObject JumpKickLeftWeapon;
    /// <summary>
    /// 右边攻击碰撞体
    /// </summary>
    public GameObject KickRightWeapon;
    public GameObject DiveKickRightWeapon;
    public GameObject JabRightWeapon;
    public GameObject JumpKickRightWeapon;

    public int hp = 100;
    private int hpHolder;
    private float speedUpArgument;


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
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

        //Move
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

        //Speed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))    //Shift speed up
        {
            speedUpArgument = 1.8f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))    //Shift speed up
        {
            speedUpArgument = 1f;
        }

        //Attack
        if (Input.GetKeyUp(KeyCode.J) && PlayerModel.Instance.KungfuEnableList["Jab"])
        {
            animator.SetTrigger("Jab");
        }
        if (Input.GetKeyUp(KeyCode.K) && PlayerModel.Instance.KungfuEnableList["Kick"])
        {
            animator.SetTrigger("Kick");
        }
        if (Input.GetKeyUp(KeyCode.L) && PlayerModel.Instance.KungfuEnableList["DiveKick"])
        {
            animator.SetTrigger("DiveKick");
        }
        if (Input.GetKeyUp(KeyCode.O) && PlayerModel.Instance.KungfuEnableList["JumpKick"])
        {
            animator.SetTrigger("JumpKick");
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
    }

    /// <summary>
    /// 跟随主角方向显示对应攻击碰撞体
    /// </summary>
    /// <param name="value"></param>
    private void setDirection(bool value)
    {
        KickLeftWeapon.SetActive(value);
        DiveKickLeftWeapon.SetActive(value);
        JabLeftWeapon.SetActive(value);
        JumpKickLeftWeapon.SetActive(value);

        KickRightWeapon.SetActive(!value);
        DiveKickRightWeapon.SetActive(!value);
        JabRightWeapon.SetActive(!value);
        JumpKickRightWeapon.SetActive(!value);
    }
}