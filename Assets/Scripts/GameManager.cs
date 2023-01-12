using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int coins = 0;

    public TextMeshProUGUI uiDistance;
    public TextMeshProUGUI uiCoins;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z);
        uiDistance.text = distance.ToString() + " m";
        uiCoins.text = coins.ToString() + " coins";
    }

    public void CoinCollected()
    {
        coins++;
    }
}
