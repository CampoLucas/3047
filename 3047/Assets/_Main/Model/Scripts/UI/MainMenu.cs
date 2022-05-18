using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu, _optionsMenu;

    [SerializeField] private GameObject _mainMenuFirstButton, _optionsFirstButton, _optionsClosedButton;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirstButton);
    }


    public void NewGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void OpenOptions()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_optionsFirstButton);
    }
    public void CloseOptions()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(_optionsClosedButton);
    }
    public void Quit() => Application.Quit();
}
