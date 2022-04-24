using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private List<Level> _levels = new List<Level>();

    private Level _currentLevel;
    private int _levelIndex;

    public UnityEvent<string> ItemChange;

    private void Start()
    {
        _uiManager.ShowStartScreen();

    }

    private void CreateLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel.gameObject);
            _currentLevel = null;
        }

        int index = _levelIndex;

        if (_levelIndex >= _levels.Count)
        {
            index = _levelIndex % _levels.Count;
        }

        _currentLevel = Instantiate(_levels[index].gameObject).GetComponent<Level>();
    }

    public void StartGame()
    {
        CreateLevel();
        _currentLevel.OnComplete += StopGame;
        _currentLevel.OnItemListChange += OnItemListChange;
        _currentLevel.Initialize();
        _uiManager.ShowGameScreen(_currentLevel.GetItemDictionary());
    }

    public void StopGame()
    {
        _levelIndex++;
        _currentLevel.OnComplete -= StopGame;
        _currentLevel.OnItemListChange -= OnItemListChange;
        _uiManager.ShowWinScreen();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void OnItemListChange(string name) => ItemChange?.Invoke(name);
}
