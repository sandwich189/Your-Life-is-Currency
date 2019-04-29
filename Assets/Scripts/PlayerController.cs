using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private int damage = 1;

    public float attackSpeed = 1f;
    private float timeBtwAttack = 0f;

    public float attackRange = 1f;
    public LayerMask hittable;
    public LayerMask shopLayer;

    public GameObject shopUI;
    private bool shopOpen = false;

    private int dir = -1;

    private Animator anim;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        damage = transform.GetComponent<Player>().damage;

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //normalized clamp diagonal movespeed
        moveVelocity = moveInput.normalized * moveSpeed;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            dir = 1;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            dir = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
        {
            if(timeBtwAttack <= 0)
            {
                Attack(damage);
                timeBtwAttack = attackSpeed;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        else
        {
            timeBtwAttack = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D shop = Physics2D.Raycast(transform.position, Vector2.right * dir, attackRange, shopLayer);

            if (!shopOpen)
            {
                if (shop)
                {
                    shopUI.SetActive(true);
                    shopOpen = true;
                }
            }
            else if (shopOpen)
            {
               shopUI.SetActive(false);
               shopOpen = false;
            }
        }

        //Animation
        if (moveInput.x != 0 || moveInput.y != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void Attack(int dmg)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * dir,attackRange,hittable);
        //Debug.Log("hit");
        if (hit)
        {
            //Debug.Log(hit.collider);
            if (hit.collider.GetComponent<resouces>())
            {
                hit.collider.GetComponent<resouces>().hp -= 1;
            }

            if (hit.collider.GetComponent<Enemy>())
            {
                hit.collider.GetComponent<Enemy>().Hit();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, Vector2.right *dir *attackRange); 
    }
}
