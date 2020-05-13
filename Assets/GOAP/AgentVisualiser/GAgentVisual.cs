using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The class to link the GAgent code with the Inspector Editor so the agent's
//properties can be displayed in the Inspector
[ExecuteInEditMode]
public class GAgentVisual : MonoBehaviour
{
    public GAgent thisAgent;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = this.GetComponent<GAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
