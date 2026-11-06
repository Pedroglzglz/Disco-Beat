using System;
using UnityEngine;

[CreateAssetMenu (fileName = "InteractionManager", menuName = "Managers/InteractionManager")]
public class InteractionManager : ScriptableObject
{
    public event Action<int> OnNPCInteracted;

    public void NPCInteracted(int npcID)
    {
        OnNPCInteracted?.Invoke(npcID);
    }
}
