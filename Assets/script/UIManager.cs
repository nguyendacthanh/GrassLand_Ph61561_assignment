using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager :MonoBehaviour
{
    public TextMeshProUGUI killCount;
    private int killC = 0;
    public TextMeshProUGUI coinCount;
    private int coinC = 0;
    public GameObject winpanel;

    public void earnCoin()
    {
        coinC++;
        killC++;
        updateUI();
        if (killC == 5 || coinC == 5)
        {
            showScreen();
        }
    }
    public void updateUI()
    {
        killCount.text = "kill: "+killC.ToString();
        coinCount.text = "Coin: " + coinC.ToString();

    }
    private void Start()
    {
        updateUI();
        winpanel.SetActive(false);
    }
    public void showScreen() { 
        winpanel.SetActive(true);
    }
}
