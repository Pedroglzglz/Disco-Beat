using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsManager", menuName = "Managers/ObjectsManager")]
public class ObjectsManager : ScriptableObject
{
    public event Action<string> OnPickedUpObject;
    public event Action<int> OnPickedUpObjectForNPC;
    public int objectID;
    private bool hasChain = false;

    private List<int> collectedIDs = new List<int>();
    private List<string> collectedNames = new List<string>();

    public void PickedUpObject(string objectName, int objectID)
    {
        if (!collectedIDs.Contains(objectID))
            collectedIDs.Add(objectID);

        if (!collectedNames.Contains(objectName))
            collectedNames.Add(objectName);

        Debug.Log($"Objeto recibido: {objectName} con ID {objectID}");

        OnPickedUpObject?.Invoke(objectName);
        OnPickedUpObjectForNPC?.Invoke(objectID);

        hasChain = true;
    }

    public bool HasCollected(int id)
    {
        return collectedIDs.Contains(id);
    }

    public bool HasCollected(string name)
    {
        return collectedNames.Contains(name);
    }

    public List<int> GetCollectedIDs()
    {
        return collectedIDs;
    }

    public List<string> GetCollectedNames()
    {
        return collectedNames;
    }

    public void ResetAll()
    {
        collectedIDs.Clear();
        collectedNames.Clear();
        hasChain = false;
    }
}