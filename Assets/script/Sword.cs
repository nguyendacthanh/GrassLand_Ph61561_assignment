using TMPro;
using UnityEngine;

public class Sword : MonoBehaviour 
{
    public GameObject sword;
    UIManager uiManager;
    private void Start()
    {
        uiManager = Object.FindFirstObjectByType<UIManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy")) {
            
            if (uiManager!=null)
            {
                uiManager.earnCoin();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject, 0.5f);

        }
    }

}
