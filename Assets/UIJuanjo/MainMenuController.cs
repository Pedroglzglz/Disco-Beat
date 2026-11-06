using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] public GameObject mainPanel;
    [SerializeField] public GameObject howToPlayPanel;
    [SerializeField] public GameObject creditsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void ShowHowToPlay()
    {
        TogglePanels(howToPlayPanel);
    }

    public void ShowCredits()
    {
        TogglePanels(creditsPanel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        TogglePanels(mainPanel);
    }

    private void TogglePanels(GameObject panelToActivate)
    {
        mainPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        creditsPanel.SetActive(false);

        panelToActivate.SetActive(true);
    }
}
