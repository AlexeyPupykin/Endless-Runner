using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private GameData gameData;

    public TextMeshProUGUI uiDistance;
    public TextMeshProUGUI uiCoins;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        RefreshUI();
    }

    void RefreshUI()
    {
        uiCoins.text = gameData.totalCoins.ToString() + " coins";
        uiDistance.text = gameData.totalDistance.ToString() + " m";
    }
}
