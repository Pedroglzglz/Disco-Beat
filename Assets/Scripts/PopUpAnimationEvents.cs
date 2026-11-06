using UnityEngine;

public class PopUpAnimationEvents : MonoBehaviour
{
    private ObjectsController objectsController;

    void OnEnable()
    {
        objectsController = FindAnyObjectByType<ObjectsController>();
    }

    public void ShowTextAndButton()
    {
        objectsController.ShowTextAndButton();
    }  
    
}
