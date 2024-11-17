using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ghost : MonoBehaviour
{
    private List<Vector3> ReplayingPositions = new List<Vector3>();
    public float ghostSpeed = 15f;
    public GameObject GhostPrefab, ghost;
    public float rotationSpeed = 10f;
    int replayIndex = 0;

    private bool isReplaying = false;

    public void CreateGhost(List<Vector3> RecoredPosition, Transform Spawn)
    {
        ghost = Instantiate(GhostPrefab);
        ghost.transform.position = Spawn.position;
        ReplayingPositions = RecoredPosition;
        isReplaying = true;
        ReplayGhost();
    }



    private void ReplayGhost()
    {
        
        if (replayIndex >= ReplayingPositions.Count) // Если путь завершён
        {
            
            Destroy(ghost.gameObject);
            replayIndex = 0;
            isReplaying = false;
            return;
        }




        Vector3 targetPosition = ReplayingPositions[replayIndex];

        Vector3 direction = targetPosition - ghost.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        ghost.transform.rotation = Quaternion.Slerp(ghost.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


        ghost.transform.position = Vector3.MoveTowards(ghost.transform.position, targetPosition, ghostSpeed * Time.deltaTime);


        // Перейти к следующей точке, если достигнута текущая
        if (Vector3.Distance(ghost.transform.position, targetPosition) < 0.1f)
        {
            replayIndex++;
        }
    }

    private void Update()
    {
        if(isReplaying)
        ReplayGhost();
    }



}
