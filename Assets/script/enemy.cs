using System.Collections;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float radius = 4f;
    public float interval = 5f;
    public float moveSpeed = 3f;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float timer;
    
    public float phamViPhatHien = 6f;
    public float atkSpeed = 1.5f;

    public Transform player;

    //check player trong tam tan cong
    private bool checkTamTanCong=false;



    //prefab cua tan cong va vi tri cua prefab tan cong se xuat hien
    public GameObject chem;
    public Transform chemPosition;



   
    private void Start()
    {
        startPosition = transform.position;
        SetRandomTargetPosition();
        timer = interval;


    }

    public void Update()
    {
        //di chuyen random
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SetRandomTargetPosition();
            timer = interval;
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        float seeSpeed=moveSpeed * 3f;
        if (distanceToPlayer <= phamViPhatHien)
        {

            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, seeSpeed * Time.deltaTime);
        }

    }

    private void SetRandomTargetPosition()
    {

        Vector2 randomPoint = Random.insideUnitCircle * radius;
        targetPosition = startPosition + randomPoint;
    }






    //private IEnumerator attackPlayer() {

    //    checkTamTanCong = true;
    //    Instantiate(chem,chemPosition.position,chemPosition.rotation);
    //yield return new WaitForSeconds(atkSpeed);
    //    checkTamTanCong=false;
    //}




    private void OnTriggerEnter2D(Collider2D orther)
    {
        //if (phamViPhatHien.CompareTag(player))
        {
            
        }
    }
}
