using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuContainer;
    [SerializeField] private GameObject missionsMenuContainer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseButtonClicked();
        }    
    }
    
    public void OnPauseButtonClicked()
    {
            Time.timeScale = 0f;
            pauseMenuContainer.SetActive(true);
            //HUDScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
    }

    public void OnResumeButtonClicked()
    {
        Time.timeScale = 1f;
        pauseMenuContainer.SetActive(false);
        //HUDScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnMissionsButtonClicked()
    {
        pauseMenuContainer.SetActive(false);
        missionsMenuContainer.SetActive(true);
    }

    public void OnBackButtonInMissionsMenuClicked()
    {
        pauseMenuContainer.SetActive(true);
        missionsMenuContainer.SetActive(false);
    }
}
