using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MLJumper
{

    public class KillOnHit : MonoBehaviour
    {
        /*
         * Prevents the usage of resources by destroying
         * all movers hitting this wall. 
         */
        private void OnCollisionEnter(Collision other)
        {
            Destroy(other.gameObject);
        }
    }
}