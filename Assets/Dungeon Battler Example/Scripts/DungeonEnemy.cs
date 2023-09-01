using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnemy : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed;

    public float attackRange;

    private DungeonPlayer player;

    public float currentHealth;

    public float freezeTime;
    private float freezeCounter;

    public GameObject deathEffect;

    public int expReward;

    public int damage;

    public DungeonExpPickup pickupToDrop;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<DungeonPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (freezeCounter > 0f)
        {
            theRB.velocity = Vector2.zero;

            freezeCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                theRB.velocity = (player.transform.position - transform.position).normalized * moveSpeed;
            }
        }
    }

    public void TakeDamage(float damageToTake)
    {
        Debug.Log(name + " took damage");
        freezeCounter = freezeTime;

        currentHealth -= damageToTake;
        if(currentHealth <= 0)
        {
            if(deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
            }

            Destroy(gameObject);

            DungeonExpPickup newPickup = Instantiate(pickupToDrop, transform.position + (transform.position - player.transform.position).normalized, transform.rotation);
            newPickup.xpAmount = expReward;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Weapon")
        {
            TakeDamage(DungeonPlayer.instance.weapon.attackPower);
        }

        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DungeonPlayer.instance.TakeDamage(damage);
        }
    }
}
