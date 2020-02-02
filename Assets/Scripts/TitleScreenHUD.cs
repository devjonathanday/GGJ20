using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHUD : MonoBehaviour
{
    public GameObject titleMenu;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    public string gameSceneName;

    public void DisplayTitle()
    {
        titleMenu.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
    public void DisplayControls()
    {
        titleMenu.SetActive(false);
        controlsMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    public void DisplayCredits()
    {
        titleMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}