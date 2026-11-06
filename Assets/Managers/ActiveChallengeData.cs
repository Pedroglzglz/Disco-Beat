using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveChallengeData", menuName = "Managers/ActiveChallengeData")]
public class ActiveChallengeData : ScriptableObject
{
    public int objectIDToGrant = -1;
    public string objectNameToGrant = "";

    public void Clear()
    {
        objectIDToGrant = -1;
        objectNameToGrant = "";
    }
}
