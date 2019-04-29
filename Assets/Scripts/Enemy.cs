using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerPos;

    public int hp = 1;

    private int attackType = 0;
    public float checkRange = 1f;
    public float speed;
    public LayerMask playerLayer;
    public LayerMask resourceLayer;

    private bool playerDetected = false;

    private Vector2 randomLocation = new Vector2(0,0);
    private float randomLocationX;
    private float randomLocationY;
    private float timeBtwNewLocation = 0;
    public float timeNewLocation = 0;

    public float max_wander_distanceX = 1;
    public float max_wander_distanceY = 1;

    private int randomdir;

    private Vector2 target = new Vector2(0,0);

    public SpriteRenderer typeIndicator;
    public Sprite[] typeIndicator_sprite;

    public Sprite[] mob_sprite;
    int random_sprite = 0;

    public float attackRange = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        attackType = Random.Range(0, 4);
        random_sprite = Random.Range(0, mob_sprite.Length);
        transform.GetComponent<SpriteRenderer>().sprite = mob_sprite[random_sprite];
        typeIndicator.sprite = typeIndicator_sprite[attackType];
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwNewLocation <= 0)
        {
            Randomlocation();
            timeBtwNewLocation = timeNewLocation;
        }
        else
        {
            timeBtwNewLocation -= Time.deltaTime;
        }

        randomLocation = new Vector2(randomLocationX, randomLocationY);

        Collider2D hit = Physics2D.OverlapCircle(transform.position, checkRange, playerLayer);
        if (hit)
        {
                playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }

        if (transform.position.x < target.x)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }

        if (playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            target = playerPos.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, randomLocation, speed * Time.deltaTime);
            target = randomLocation;
        }

        RaycastHit2D playercheck = Physics2D.Raycast(transform.position, -transform.right, attackRange, playerLayer);
        RaycastHit2D collidercheck = Physics2D.Raycast(transform.position, -transform.right, attackRange, resourceLayer);

        if (playercheck)
        {
            Debug.Log(playercheck.collider);
            playercheck.collider.gameObject.GetComponent<Player>().Hit(attackType);
        }

        if (collidercheck)
        {
            Randomlocation();
        }


        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Randomlocation()
    {
        randomdir = Random.Range(0, 2);
        if (randomdir == 0)
        {
            randomdir = -1;
        }

        randomLocationX = Random.Range(transform.position.x, transform.position.x + max_wander_distanceX) * randomdir;
        randomLocationY = Random.Range(transform.position.y, transform.position.y + max_wander_distanceY) * randomdir;
    }

    public void Hit()
    {
        hp -= 1;
    }
}
