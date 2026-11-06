using UnityEngine;

public class CancionInventadaPrimera : MonoBehaviour
{
    public AudioSource song;
    public GameObject notePrefab;
    public float noteTravelTime = 3.0f;

    public float[] beatTimes = new float[] {
    };

    public Transform[] instantiationLanes;

    private float[] relativeSpawnTimes;
    private double startDSPTime; // 🕒 reloj de audio preciso
    private int noteIndex = 0;
    private bool gameStarted = false;
    private bool songScheduled = false;
    private int lastLaneIndex = -1;

    void Start()
    {
        relativeSpawnTimes = new float[beatTimes.Length];
        for (int i = 0; i < beatTimes.Length; i++)
        {
            relativeSpawnTimes[i] = beatTimes[i] - beatTimes[0];
        }
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            startDSPTime = AudioSettings.dspTime;
            double delay = noteTravelTime - beatTimes[0];
            song.PlayScheduled(startDSPTime + delay);
            gameStarted = true;
            songScheduled = true;

            Debug.Log($"🎮 Space pulsado. Canción programada para DSP + {delay:F3}s");
        }

        if (!gameStarted) return;

        double dspElapsed = AudioSettings.dspTime - startDSPTime;

        if (noteIndex < relativeSpawnTimes.Length && dspElapsed >= relativeSpawnTimes[noteIndex])
        {
            SpawnNote(noteIndex);
            noteIndex++;
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
        Debug.Log($"[SPAWN] Nota {index + 1} en lane {laneIndex} a dspElapsed={AudioSettings.dspTime - startDSPTime:F3}s " +
                  $"→ debe llegar a Y=0 en beatTime={beatTimes[index]:F3}s");
    }
}