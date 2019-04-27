using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public int damage = 1;

    public float attackSpeed = 1f;
    private float timeBtwAttack = 0f;

    public float attackRange = 1f;
    public LayerMask hittable;

    private int dir = -1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButton(0))
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
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawRay(transform.position, Vector2.right *dir *attackRange); 
    }
}
