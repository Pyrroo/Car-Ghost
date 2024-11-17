using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{    
    public GameObject PlayerPrefab;
    public Ghost GhostREF;
    public GameUI UI;
    public Transform Spawn;
    public TrackRecorder TR;

    private List<Vector3> recordedPositions = new List<Vector3>();
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        UI.HideEndCanvas();
        UI.ShowGameCanvas();
        if (recordedPositions.Count == 0)
        {
            UI.textgc.text = "Гонка в одиночку";
            GameObject player = Instantiate(PlayerPrefab);
            player.transform.position = Spawn.transform.position;

            TR.StartRecording(player);
            CameraFollow.DefinitionTarget();
            Debug.Log(recordedPositions.Count);
        }
        else
        {
            UI.textgc.text = "Гонка с Призраком";
            GameObject player = Instantiate(PlayerPrefab);
            player.transform.position = Spawn.transform.position;
            CameraFollow.DefinitionTarget();
            GhostREF.CreateGhost(recordedPositions, Spawn);
            Debug.Log(recordedPositions.Count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.ShowEndCanvas();
        UI.HideGameCanvas();
        Transform root = other.transform.root;
        recordedPositions = TR.StopRecording();
        Destroy(root.gameObject);
    }


}
