using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayer : MonoBehaviour
{
    public static DungeonPlayer instance;
    private void Awake()
    {
        instance = this;
    }

    public Rigidbody2D theRB;

    public float moveSpeed;

    public Animator anim;

    public DungeonWeaponController weapon;

    public int currentHealth;

    public float invincibleTime = .5f;
    private float invCounter;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = DungeonPlayerStats.instance.maxHP;

        weapon.SetUp();

        DungeonUIController.instance.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = Vector2.zero;
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        theRB.velocity = moveInput * moveSpeed;

        anim.SetBool("isMoving", moveInput.magnitude > 0.1f);

        //flip character
        if(moveInput.x < - 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(moveInput.x > 0.1f)
        {
            transform.localScale = Vector3.one;
        }
        //attack
        if(Input.GetMouseButtonDown(0))
        {
            weapon.DoAttack();
        }

        if(invCounter > 0)
        {
            invCounter -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damageToTake)
    {
        if (invCounter <= 0 &&  damageToTake - DungeonPlayerStats.instance.defence > 0)
        {

            currentHealth -= damageToTake - DungeonPlayerStats.instance.defence;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                DungeonUIController.instance.ShowGameOver();

                gameObject.SetActive(false);
            }

            invCounter = invincibleTime;
        }

        DungeonUIController.instance.UpdateUI();
    }
}
