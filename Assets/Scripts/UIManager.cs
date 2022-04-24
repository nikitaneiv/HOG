using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _winScreen;

    private GameObject _currentScreen;
    private UIGameScreen _uiGameScreen;

    private void Awake()
    {
        _currentScreen = _startScreen;
        _uiGameScreen = _gameScreen.GetComponent<UIGameScreen>();
    }

    public void ShowGameScreen(Dictionary<string, GameItemData> itemData)
    {
        _currentScreen.SetActive(false);
        _uiGameScreen.Initialize(itemData);
        _gameScreen.SetActive(true);
        _currentScreen = _gameScreen;
    }
    public void ShowStartScreen()
    {
        _currentScreen.SetActive(false);
        _startScreen.SetActive(true);
        _currentScreen = _startScreen;
    }
    public void ShowWinScreen()
    {
        _currentScreen.SetActive(false);
        _winScreen.SetActive(true);
        _currentScreen = _winScreen;
    }
}
