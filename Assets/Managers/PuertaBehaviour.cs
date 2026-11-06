using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBehaviour : MonoBehaviour
{
    [SerializeField] private PuertasManager puertasManagerSO;

    private void OnEnable()
    {
        puertasManagerSO.OnChallengeSucceded += Disable;
    }

        private void OnDisable()
    {
        puertasManagerSO.OnChallengeSucceded -= Disable;
    }
    
    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
