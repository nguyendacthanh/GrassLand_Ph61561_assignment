using TMPro;
using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public TextMeshProUGUI killCount;
    public TextMeshProUGUI coinsScore;
    private int killC = 0;
    private int coinsS = 0;
    bool checkCoins=false;
    bool checkKill = false;
    public GameObject winpanel;

    UIManager uiManager;
    Vector2 shoot;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    public GameObject potisionAtk;
    public GameObject prefabSword;
    void Start()
    {
        winpanel.SetActive(false);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y !=0)
        {
            animator.SetBool("run1", true);

        }
        else { animator.SetBool("run1", false); }
        if (Input.GetKeyDown(KeyCode.E))
        {
            attack();
            //animator.SetTrigger("atk1");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //fire();
            //animator.SetTrigger("atk1");
        }



    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void attack()
    {   
        Vector3 vitritancong= potisionAtk.transform.position;
        GameObject sword = Instantiate(prefabSword, vitritancong,Quaternion.identity);
        Destroy(sword, 0.5f);
    }
    private void coinsCount()
    {
        if (coinsScore != null)
        {
            coinsScore.text = "coin score: " + coinsS;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("coins")) {
    //        coinsS++;
    //        coinsCount();
    //        checkCoins=true;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coins"))
        {
            coinsS++;
            if (uiManager != null)
            {
                uiManager.earnCoin();
            }

            coinsCount();
            checkCoins = true;
            Destroy(collision.gameObject);
            
        }
    }


    //void fire() {
    //    Vector3 vitritancong = potisionAtk.transform.position;

    //    GameObject bullet = Instantiate(prefabSword, vitritancong,Quaternion.identity);
    //    Destroy(bullet, 0.5f);

    //    Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();
    //    if (movement.x>0) { 
    //    shoot=Vector2.right;
    //    }
    //    rbbullet.linearVelocity = shoot * 100;
    //}
}
