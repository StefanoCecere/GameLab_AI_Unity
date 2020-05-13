using System.Collections.Generic;
using UnityEngine;

public class GInventory {
    // Store our items in a List
    public List<GameObject> items = new List<GameObject>();

    // Method to add items to our list
    public void AddItem(GameObject i) {

        items.Add(i);
    }

    // Method to search for a particular item
    public GameObject FindItemWithTag(string tag) {

        // Iterate through all the items
        foreach (GameObject i in items) {

            // Found a match
            if (i.tag == tag) {

                return i;
            }
        }
        // Nothing found
        return null;
    }

    // Remove an item from our list
    public void RemoveItem(GameObject i) {

        int indexToRemove = -1;

        // Search through the list to see if it exists
        foreach (GameObject g in items) {

            // Initially set indexToRemove to 0. The first item in the List
            indexToRemove++;
            // Have we found it?
            if (g == i) {

                break;
            }
        }
        // Do we have something to remove?
        if (indexToRemove >= 1) {

            // Yes we do.  So remove the item at indexToRemove
            items.RemoveAt(indexToRemove);
        }
    }
}
