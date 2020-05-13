using System.Collections.Generic;

//make the dictionary elements their own serializable class
//so we can edit them in the inspector
[System.Serializable]
public class WorldState {

    public string key;
    public int value;
}

public class WorldStates {

    // Constructor
    public Dictionary<string, int> states;

    public WorldStates() {

        states = new Dictionary<string, int>();
    }

    /************** Helper funtions ****************/
    // Check for a key
    public bool HasState(string key) {

        return states.ContainsKey(key);
    }

    // Add to our dictionary
    private void AddState(string key, int value) {

        states.Add(key, value);
    }

    public void ModifyState(string key, int value) {

        // If it contains this key
        if (HasState(key)) {

            // Add the value to the state
            states[key] += value;
            // If it's less than zero then remove it
            if (states[key] <= 0) {

                // Call the RemoveState method
                RemoveState(key);
            }
        } else {

            AddState(key, value);
        }
    }

    // Method to remove a state
    public void RemoveState(string key) {

        // Check if it frist exists
        if (HasState(key)) {

            states.Remove(key);
        }
    }

    // Set a state
    public void SetState(string key, int value) {

        // Check if it exists
        if (HasState(key)) {

            states[key] = value;
        } else {

            AddState(key, value);
        }
    }

    public Dictionary<string, int> GetStates() {

        return states;
    }
}
