public class Rest : GAction {
    public override bool PrePerform() {

        return true;
    }

    public override bool PostPerform() {

        //the agent will no longer believe they need a rest
        beliefs.RemoveState("exhausted");
        return true;
    }
}
