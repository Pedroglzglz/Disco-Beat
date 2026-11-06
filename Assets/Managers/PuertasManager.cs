using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu (fileName = "PuertasManager", menuName = "Managers/PuertasManager")]
public class PuertasManager : ScriptableObject
{
    public event Action OnChallengeSucceded;
    // Start is called before the first frame update
  

    public void ChallengeCompleted()
    {
        OnChallengeSucceded?.Invoke();
    }
}
