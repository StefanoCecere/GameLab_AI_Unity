using UnityEngine;

namespace flocking
{
    public class FlockManager : MonoBehaviour
    {

        // Access the fish prefab
        public GameObject fishPrefab;
        // Starting number of fish
        public int numFish = 20;
        // Array of fish prefabs
        public GameObject[] allFish;
        // Swimming bounds for fish
        public Vector3 swimLimits = new Vector3(5.0f, 5.0f, 5.0f);
        // Goal position
        public Vector3 goalPos;

        // Header title for Unity Editor
        [Header("Fish Settings")]
        [Range(0.0f, 5.0f)]
        public float minSpeed;          // Minimum speed range
        [Range(0.0f, 5.0f)]
        public float maxSpeed;          // Maximum speed range
        [Range(1.0f, 10.0f)]
        public float neighbourDistance; // Prefab neighbout distance
        [Range(0.0f, 5.0f)]
        public float rotationSpeed;     // Speed at which the prefabs rotate

        void Start()
        {
            // Allocate the allFish array
            allFish = new GameObject[numFish];
            // Loop throught the array instantiating the prefabs.  In this case fish
            for (int i = 0; i < numFish; ++i)
            {

                Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                    Random.Range(-swimLimits.x, swimLimits.x),
                                                                    Random.Range(-swimLimits.x, swimLimits.x));
                allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
                allFish[i].GetComponent<Flock>().myManager = this;
            }

            // Target for the prefbas to head for
            goalPos = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            // Update the target for the prefabs to head for with a random chance
            if (Random.Range(0.0f, 100.0f) < 10.0f)
            {
                goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x),
                                                                Random.Range(-swimLimits.x, swimLimits.x));
            }
        }
    }
}