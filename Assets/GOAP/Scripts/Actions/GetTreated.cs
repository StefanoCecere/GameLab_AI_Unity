public class GetTreated : GAction {

    public override bool PrePerform() {

        // Get a free cubicle
        target = inventory.FindItemWithTag("Cubicle");
        // Check that we did indeed get a cubicle
        if (target == null)
            // No cubicle so return false
            return false;
        // All good
        return true;
    }

    public override bool PostPerform() {

        // Add a new state "Treated"
        GWorld.Instance.GetWorld().ModifyState("Treated", 1);
        // Add isCured to agents beliefs
        beliefs.ModifyState("isCured", 1);
        // Remove the cubicle from the list
        inventory.RemoveItem(target);
        return true;
    }
}
