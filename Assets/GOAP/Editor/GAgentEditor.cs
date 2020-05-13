using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GAgentVisual))]
[CanEditMultipleObjects]
public class GAgentVisualEditor : Editor {


    void OnEnable() {

    }

    //Display properties of the GAgent in the Inspector
    public override void OnInspectorGUI() {
        //Draw the default items in the Inspector as Unity would without
        //this script
        DrawDefaultInspector();

        //syncronise values from the running of the code eith the script properties
        serializedObject.Update();

        //get the agent game object so the GAgent and associated properties can
        //be displayed
        GAgentVisual agent = (GAgentVisual)target;
        GUILayout.Label("Name: " + agent.name);
        GUILayout.Label("Current Action: " + agent.gameObject.GetComponent<GAgent>().currentAction);
        GUILayout.Label("Actions: ");
        foreach (GAction a in agent.gameObject.GetComponent<GAgent>().actions) {
            string pre = "";
            string eff = "";

            foreach (KeyValuePair<string, int> p in a.preconditions)
                pre += p.Key + ", ";
            foreach (KeyValuePair<string, int> e in a.effects)
                eff += e.Key + ", ";

            GUILayout.Label("====  " + a.actionName + "(" + pre + ")(" + eff + ")");
        }
        GUILayout.Label("Goals: ");
        foreach (KeyValuePair<SubGoal, int> g in agent.gameObject.GetComponent<GAgent>().goals) {
            GUILayout.Label("---: ");
            foreach (KeyValuePair<string, int> sg in g.Key.sGoals)
                GUILayout.Label("=====  " + sg.Key);
        }
        GUILayout.Label("Beliefs: ");
        foreach (KeyValuePair<string, int> sg in agent.gameObject.GetComponent<GAgent>().beliefs.GetStates()) {
            GUILayout.Label("=====  " + sg.Key);
        }

        GUILayout.Label("Inventory: ");
        foreach (GameObject g in agent.gameObject.GetComponent<GAgent>().inventory.items) {
            GUILayout.Label("====  " + g.tag);
        }


        serializedObject.ApplyModifiedProperties();
    }
}
