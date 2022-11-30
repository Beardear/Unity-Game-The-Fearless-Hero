using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;

    //Outlet
    private NavMeshAgent agent;
    public Slider slider;
    public Animator animator;
    public Rigidbody2D _rigidbody2D;
    public GameObject Book;
    public GameObject damageCanvas;

    private int hp = 100;
    private int hpHolder;
    private Vector3 lastpos;


    private bool canAttack = false;
    public float autoAttackTime = 0;
    public float autoAttackCd = 1;
    public BoxCollider2D weapon;
    //Configuration
    //public Transform target;

    //Methods
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.rotation = Quaternion.identity;

        lastpos = transform.position;

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        hpHolder = hp;

    }
    void Update()
    {
        animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);

        //Navimesh
        //float agentOffset = 0.0001f;
        //Vector3 agentPos = (Vector3)(agentOffset * Random.insideUnitCircle) + target.position;
        //agent.SetDestination(agentPos);
        agent.SetDestination(target.position);

        //Attack one time per second
        if (canAttack)
        {
            autoAttackTime += Time.deltaTime;
        }
        if (autoAttackTime > autoAttackCd)
        {
            autoAttackTime = 0;
            attackthePlayer();
        }

        //Animation Walk

        if ((transform.position - lastpos).sqrMagnitude > 0.001f)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        lastpos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hp <= 0) return;
        
        if (collision.collider.tag == "Player")                 //Enable Enemies' attacks
        {
            canAttack = true;
        }

        double damageArgPlayer = PlayerModel.Instance.Lv * 0.15 + 1;                //Calculate Player's damage factor
        print(damageArgPlayer);
        if (collision.collider.name == "JabLeftWeapon" || collision.collider.name == "JabRightWeapon")
        {
            double damage = 12 * damageArgPlayer;
            damage = Random.Range((float)damage - 3, (float)damage + 3);
            hp -= (int)damage;
            slider.value = (float)hp / hpHolder;
            InstanceManager.Instance.soundManager.playJabAudio();

            DamageDigits damageDigits = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageDigits>(); // Digital Effects
            damageDigits.ShowUIDamage(Mathf.RoundToInt((float)damage));
        }
        else if (collision.collider.name == "KickLeftWeapon" || collision.collider.name == "KickRightWeapon")
        {
            double damage = 18 * damageArgPlayer;
            damage = Random.Range((float)damage - 3, (float)damage + 3);
            hp -= (int)damage;
            slider.value = (float)hp / hpHolder;
            InstanceManager.Instance.soundManager.playKickAudio();

            DamageDigits damageDigits = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageDigits>();
            damageDigits.ShowUIDamage(Mathf.RoundToInt((float)damage));
        }
        else if (collision.collider.name == "DiveKickLeftWeapon" || collision.collider.name == "DiveKickRightWeapon")
        {
            double damage = 36 * damageArgPlayer;
            damage = Random.Range((float)damage - 3, (float)damage + 3);
            hp -= (int)damage;
            slider.value = (float)hp / hpHolder;
            InstanceManager.Instance.soundManager.playDiveKickAudio();

            DamageDigits damageDigits = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageDigits>();
            damageDigits.ShowUIDamage(Mathf.RoundToInt((float)damage));
        }
        else if (collision.collider.name == "JumpKickLeftWeapon" || collision.collider.name == "JumpKickRightWeapon")
        {
            double damage = 50 * damageArgPlayer;
            damage = Random.Range((float)damage - 3, (float)damage + 3);
            hp -= (int)damage;
            slider.value = (float)hp / hpHolder;
            InstanceManager.Instance.soundManager.playJumpKickAudio();

            DamageDigits damageDigits = Instantiate(damageCanvas, transform.position, Quaternion.identity).GetComponent<DamageDigits>();
            damageDigits.ShowUIDamage(Mathf.RoundToInt((float)damage));
        }
        else
        {
            return;
        }

        if (hp <= 0)
        {
            InstanceManager.Instance.enemyBorn.curEnemyCounter--;
            animator.SetTrigger("Death");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.otherCollider.tag == "Monster")
        {
            canAttack = false;
            autoAttackTime = 0;
        }
    }

    private void attackthePlayer()
    {
        print("怪物攻击");
        weapon.enabled = true;
        animator.SetTrigger("Attack");
    }

    private void enemyDeath()           //死亡动画结束后调用
    {
        //Add LvValue to Player
        PlayerModel.Instance.addLvValue(36);        //一个怪36点经验

        //胜利
        if (InstanceManager.Instance.enemyBorn.curEnemyCounter <= 0 && InstanceManager.Instance.enemyBorn.bornFinished == true && GameController.instance.bookNum == false)
        {
            //掉落书
            //Random Positions
            //X介于2-8，Y介于-4--1
            Vector3 newPosition = InstanceManager.Instance.enemyBorn.transform.position;
            newPosition.x += Random.Range(0, 6.0f);
            newPosition.y += Random.Range(0, 3.0f);

            //生成一本书
            Instantiate(Book, newPosition, Quaternion.identity);
            GameController.instance.bookNum = true;
        }

        Destroy(this.gameObject);
    }
}

//if (collision.collider.tag == "Weapon_Kick")
//{
//    hp -= 15;
//    slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
//}
//else if (collision.collider.tag == "Weapon_DiveKick")
//{
//    hp -= 30;
//    slider.value = (float)hp / hpHolder;//通过改变value的值（float类型）来改变血条长度。
//}