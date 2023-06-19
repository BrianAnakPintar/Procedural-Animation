using System.Collections.Generic;
using UnityEngine;

public class LegController : MonoBehaviour
{
    // This dictionary holds the casters and the legs that they're responsible for handling
    public Dictionary<GameObject, GameObject> castersToLegs = new Dictionary<GameObject, GameObject>();
    public Dictionary<GameObject, GameObject> legsToCasters = new Dictionary<GameObject, GameObject>();

    public float maxDistance;
    public float speed;
    public float stepHeight;

    public PlayerController playerController;

    private Queue<GameObject> legsWaitlist = new Queue<GameObject>();
    private Queue<Vector3> newPositions = new Queue<Vector3>();
    public bool currentlyMoving;
    private GameObject currentLeg;
    private Vector3 initialLegPos;
    private Vector3 destinationPos;
    public float lerp;

    // Since Unity does not make dictionaries serializable. I shall initialize them from here instead
    private void Awake()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Targets");

        for (int i = 0; i < targets.Length; i++)
        {
            LegsTracker lt = targets[i].GetComponent<LegsTracker>();
            GameObject caster = lt.caster;
            castersToLegs.Add(caster, targets[i]);
            legsToCasters.Add(targets[i], caster);
        }
    }

    void Update()
    {
        foreach (GameObject caster in castersToLegs.Keys)
        {
            Ray ray = new Ray(caster.transform.position, Vector3.down);
            // If we hit something from the raycast
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                // First we check if the leg is outside our max-distance range (In a sense it works like a sphere)
                if (Vector3.Distance(castersToLegs[caster].transform.position, hitInfo.point) > maxDistance)
                {
                    if (!legsWaitlist.Contains(castersToLegs[caster]))
                    {
                        legsWaitlist.Enqueue(castersToLegs[caster]);
                        newPositions.Enqueue(hitInfo.point);
                    }
                }
            }
        }

        // If we have something on the queue and we're not moving then we want to move the first item in the queu
        if (legsWaitlist.Count >= 1 && !currentlyMoving)
        {
            currentlyMoving = true;
            lerp = 0;
            currentLeg = legsWaitlist.Dequeue();
            destinationPos = newPositions.Dequeue();
            initialLegPos = currentLeg.transform.position;
        }

        if (currentlyMoving)
        {
            Vector3 destination = destinationPos + 
                                  (playerController.getMovementVector().normalized) * maxDistance;
            Vector3 newPos = Vector3.Lerp(initialLegPos, destination, lerp);
            newPos.y += Mathf.Sin(lerp * Mathf.PI) * stepHeight;

            currentLeg.transform.position = newPos;

            lerp += speed * Time.deltaTime;
        }

        // This indicates that we're done moving
        if (lerp >= 1)
        {
            currentlyMoving = false;
            initialLegPos = currentLeg.transform.position;
        }
    }
}
