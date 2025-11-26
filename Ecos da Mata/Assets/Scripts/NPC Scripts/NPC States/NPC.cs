using UnityEngine;

public class NPC : MonoBehaviour
{

    public enum NPCState { Default, Idle, Wander, Talk }
    public NPCState currentState = NPCState.Wander;
    private NPCState defaultState;

    public NPC_Wander wander;
    public NPC_Talk talk;


    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);
    }

    public void SwitchState(NPCState newState)
    {
        currentState = newState;

        wander.enabled = newState == NPCState.Wander;
        talk.enabled = newState == NPCState.Talk;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(NPCState.Talk);
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(defaultState);
    }
}
