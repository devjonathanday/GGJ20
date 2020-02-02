using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenHUD : MonoBehaviour
{
    public GameObject titleMenu;
    public GameObject controlsMenu;
    public string gameSceneName;

    public void DisplayControls()
    {
        controlsMenu.SetActive(true);
        titleMenu.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
}