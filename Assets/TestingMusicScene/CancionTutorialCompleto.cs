using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancionTutorialCompleto : MonoBehaviour
{
    public AudioSource song;
    public GameObject notePrefab;
    public float noteTravelTime = 3.0f;

    public float[] beatTimes = new float[] {
        // Aquí tus tiempos reales, todos ≥ 3.0
    };

    public Transform[] instantiationLanes;

    private float[] spawnTimes;
    private int spawnIndex = 0;
    private bool hasStarted = false;
    private int lastLaneIndex = -1;

    void Start()
    {
        // Precalculamos los tiempos de spawn
        spawnTimes = new float[beatTimes.Length];
        for (int i = 0; i < beatTimes.Length; i++)
        {
            spawnTimes[i] = beatTimes[i] - noteTravelTime;
        }
    }

    void Update()
    {
        // Pulsamos Space para empezar
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            song.Play();
            hasStarted = true;
            Debug.Log("🎵 Canción iniciada.");
        }

        if (!hasStarted) return;

        // Instanciamos las notas según song.time
        if (spawnIndex < spawnTimes.Length && song.time >= spawnTimes[spawnIndex])
        {
            SpawnNote(spawnIndex);
            spawnIndex++;
        }
    }

    void SpawnNote(int index)
    {
        int laneIndex;
        do
        {
            laneIndex = Random.Range(0, instantiationLanes.Length);
        } while (laneIndex == lastLaneIndex);
        lastLaneIndex = laneIndex;

        Instantiate(notePrefab, instantiationLanes[laneIndex].position, Quaternion.identity);
        Debug.Log($"[SPAWN] Nota {index + 1} instanciada a song.time={song.time:F3}s (llegará en {beatTimes[index]:F3}s)");
    }
}