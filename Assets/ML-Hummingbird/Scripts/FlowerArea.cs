using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hummingbird
{
    /// <summary>
    /// Manages a collection of flower plants and attached flowers
    /// </summary>
    public class FlowerArea : MonoBehaviour
    {
        // The diameter of the area where the agent and flowers can be
        // used for observing relative distance from agent to flower
        public const float AreaDiameter = 20f;

        // The list of all flower plants in this flower area (flower plants have multiple flowers)
        private List<GameObject> flowerPlants;

        // A lookup dictionary for looking up a flower from a nectar collider
        private Dictionary<Collider, Flower> nectarFlowerDictionary;

        /// <summary>
        /// The list of all flowers in the flower area
        /// </summary>
        public List<Flower> Flowers { get; private set; }

        /// <summary>
        /// Reset the flowers and flower plants
        /// </summary>
        public void ResetFlowers()
        {
            // Rotate each flower plant around the Y axis and subtly around X and Z
            foreach (GameObject flowerPlant in flowerPlants)
            {
                float xRotation = UnityEngine.Random.Range(-5f, 5f);
                float yRotation = UnityEngine.Random.Range(-180f, 180f);
                float zRotation = UnityEngine.Random.Range(-5f, 5f);
                flowerPlant.transform.localRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            }

            // Reset each flower
            foreach (Flower flower in Flowers)
            {
                flower.ResetFlower();
            }
        }

        /// <summary>
        /// Gets the <see cref="Flower"/> that a nectar collider belongs to
        /// </summary>
        /// <param name="collider">The nectar collider</param>
        /// <returns>The matching flower</returns>
        public Flower GetFlowerFromNectar(Collider collider)
        {
            return nectarFlowerDictionary[collider];
        }

        /// <summary>
        /// Called when the area wakes up
        /// </summary>
        private void Awake()
        {
            // Initialize variables
            flowerPlants = new List<GameObject>();
            nectarFlowerDictionary = new Dictionary<Collider, Flower>();
            Flowers = new List<Flower>();
        }

        /// <summary>
        /// Called when the game starts
        /// </summary>
        private void Start()
        {
            // Find all flowers that are children of this GameObject/Transform
            FindChildFlowers(transform);
        }

        /// <summary>
        /// Recursively finds all flowers and flower plants that are children of a parent transform
        /// </summary>
        /// <param name="parent">The parent of the children to check</param>
        private void FindChildFlowers(Transform parent)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);

                if (child.CompareTag("flower_plant"))
                {
                    // Found a flower plant, add it to the flowerPlants list
                    flowerPlants.Add(child.gameObject);

                    // Look for flowers within the flower plant
                    FindChildFlowers(child);
                }
                else
                {
                    // Not a flower plant, look for a Flower component
                    Flower flower = child.GetComponent<Flower>();
                    if (flower != null)
                    {
                        // Found a flower, add it to the Flowers list
                        Flowers.Add(flower);

                        // Add the nectar collider to the lookup dictionary
                        nectarFlowerDictionary.Add(flower.nectarCollider, flower);

                        // Note: there are no flowers that are children of other flowers
                    }
                    else
                    {
                        // Flower component not found, so check children
                        FindChildFlowers(child);
                    }
                }
            }
        }
    }
}