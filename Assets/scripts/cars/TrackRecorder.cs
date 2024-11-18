using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRecorder : MonoBehaviour
{
    private GameObject RecordTarget;
    private float recordInterval = 0.5f;
    private List<Vector3> recordedPositions = new List<Vector3>();

    // Скрипт записи маршрута
    public void StartRecording(GameObject playerREF)
    {
        recordedPositions.Clear();
        RecordTarget = playerREF;
        InvokeRepeating(nameof(RecordPosition), 0f, recordInterval);
    }
    private void RecordPosition()
    {
        recordedPositions.Add(RecordTarget.transform.position);
        Debug.Log(recordedPositions[recordedPositions.Count - 1]);
    }

    public List<Vector3> StopRecording()
    {
        CancelInvoke(nameof(RecordPosition));
        return recordedPositions;
    }

}
