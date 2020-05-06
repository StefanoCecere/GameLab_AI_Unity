using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    // Agents destination
    public GameObject goal;
    // Get the prefab
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // Access the agents NavMesh
        agent = this.GetComponent<NavMeshAgent>();
        // Instruct the agent where it has to go
        agent.SetDestination(goal.transform.position);
    }
}
