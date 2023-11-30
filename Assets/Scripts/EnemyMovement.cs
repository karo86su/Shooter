using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;

    public float squareOfMovement = 20f;
    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;

    public float closeEnough = 3f;

    private float xPos;
    private float yPos;
    private float zPos;

    private void Awake()
    {
        minX = minZ = -squareOfMovement;
        maxX = maxZ = squareOfMovement;

        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPos, yPos, zPos)) <= closeEnough) 
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPos = Random.Range(minX, maxX);
        yPos = transform.position.y;
        zPos = Random.Range(minZ, maxZ);

        agent.SetDestination(new Vector3 (xPos, yPos, zPos));
    }

}
