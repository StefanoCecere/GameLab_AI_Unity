using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWorld : MonoBehaviour {

    // Storage for the states
    public Text states;

    void LateUpdate() {

        // Dictionary of states
        Dictionary<string, int> worldStates = GWorld.Instance.GetWorld().GetStates();
        // Clear out the states text
        states.text = "";
        // Cycle through them all and store in states.text
        foreach (KeyValuePair<string, int> s in worldStates) {

            states.text += s.Key + ", " + s.Value + "\n";
        }
    }
}
