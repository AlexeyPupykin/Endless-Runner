using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    private int coins = 0;

    public TextMeshProUGUI uiDistance;
    public TextMeshProUGUI uiCoins;
    public GameObject gameOverMenu;

    public GameData gameData;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    void Start()
    {
        player = GameObject.Find("Player");   
    }

    void Update()
    {
        if (!player) return;

        int distance = Mathf.RoundToInt(player.transform.position.z);
        uiDistance.text = distance.ToString() + " m";
        uiCoins.text = coins.ToString() + " coins";
    }

    public void CoinCollected()
    {
        coins++;
    }

    public void GameOver()
    {
        gameData.totalCoins += coins;
        gameData.totalDistance += Mathf.RoundToInt(player.transform.position.z);
        SaveSystem.Save(gameData);

        gameOverMenu.SetActive(true);
    }
}
