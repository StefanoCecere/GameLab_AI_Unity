using UnityEngine;

namespace flocking
{
    public class Flock : MonoBehaviour
    {

        // Access the FlockManager script
        public FlockManager myManager;
        // Prefab initial speed;
        float speed;
        // Bool used to check the swim limits
        bool turning = false;

        void Start()
        {
            // Assign a random speed to each this prefab
            speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
        }

        // Update is called once per frame
        void Update()
        {
            // Determine the bounding box of the manager cube
            Bounds b = new Bounds(myManager.transform.position, myManager.swimLimits * 2.0f);

            // If the fish is outside the bounds of the cube or about to hit something
            // then start turning around
            RaycastHit hit = new RaycastHit();
            Vector3 direction = Vector3.zero;

            if (!b.Contains(transform.position))
            {

                turning = true;
                direction = myManager.transform.position - transform.position;
            }
            else if (Physics.Raycast(transform.position, this.transform.forward * 50.0f, out hit))
            {
                turning = true;
                //Debug.DrawRay(this.transform.position, this.transform.forward * 50.0f, Color.red);
                direction = Vector3.Reflect(this.transform.forward, hit.normal);
            }
            else
            {

                turning = false;
            }

            // Test if we're turning
            if (turning)
            {

                // Turn towards the centre of the cube
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      myManager.rotationSpeed * Time.deltaTime);
            }
            else
            {

                // 10% chance of altering prefab speed
                if (Random.Range(0.0f, 100.0f) < 10.0f)
                {

                    speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
                }

                // 20& chance of applying the flocking rules
                if (Random.Range(0.0f, 100.0f) < 20.0f)
                {

                    ApplyRules();
                }
            }

            transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
        }

        void ApplyRules()
        {

            GameObject[] gos;
            gos = myManager.allFish;

            Vector3 vcentre = Vector3.zero;
            Vector3 vavoid = Vector3.zero;
            float gSpeed = 0.01f;
            float nDistance;
            int groupSize = 0;

            foreach (GameObject go in gos)
            {

                if (go != this.gameObject)
                {

                    nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                    if (nDistance <= myManager.neighbourDistance)
                    {

                        vcentre += go.transform.position;
                        groupSize++;

                        if (nDistance < 1.0f)
                        {

                            vavoid = vavoid + (this.transform.position - go.transform.position);
                        }

                        Flock anotherFlock = go.GetComponent<Flock>();
                        gSpeed = gSpeed + anotherFlock.speed;
                    }
                }
            }

            if (groupSize > 0)
            {

                // Find the average centre of the group then add a vector to the target (goalPos)
                vcentre = vcentre / groupSize + (myManager.goalPos - this.transform.position);
                speed = gSpeed / groupSize;

                Vector3 direction = (vcentre + vavoid) - transform.position;
                if (direction != Vector3.zero)
                {

                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                                          Quaternion.LookRotation(direction),
                                                          myManager.rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}