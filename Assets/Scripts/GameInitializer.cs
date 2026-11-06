using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private ObjectsManager objectsManagerSO;

    private void Awake()
    {
        #if UNITY_EDITOR
        if (!Application.isPlaying) return;
        if (Time.frameCount < 3)
        {
            objectsManagerSO.ResetAll();
            Debug.Log("🔄 ObjectsManager reset al iniciar modo Play.");
        }
        #endif
    }
}