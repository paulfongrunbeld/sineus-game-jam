
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerSetBehavior : MonoBehaviour
{
    [SerializeField] private List<BaseBehavior> behaviorsList;
    [SerializeField] private BaseBehavior currentBehavior;
   

    public enum Behaviors
    {
       IdleDown,
       IdleUp,
       IdleSide,
       WalkDown,
       WalkUp,
       WalkSide,
       AttackDown,
       AttackUp,
       AttackSide,
       Death

    }
    public Behaviors Behavior
    {
        get { return (Behaviors)GetComponent<Animator>().GetInteger("behavior"); }
        set { GetComponent<Animator>().SetInteger("behavior", (int)value); }
    }

    private void Awake()
    {
        behaviorsList = new List<BaseBehavior>()
        {
           GetComponent<MovementPlayerBehavior>(),
           GetComponent<AttackPlayerBehavior>()
        };
        SetBehaviorMovement();
    }

    private void SetBehavior(BaseBehavior newBehavior)
    {
        if (this.currentBehavior != null) this.currentBehavior.Exit();
        this.currentBehavior = newBehavior;
        currentBehavior.enabled = true;
        this.currentBehavior.Enter();
    }
    private void Update()
    {
        if (this.currentBehavior != null) this.currentBehavior.Update();
    }

    public void SetBehaviorMovement()
    {
        var behavior = behaviorsList[0];
        this.SetBehavior(behavior);
    }

    public void SetBehaviorAttack()
    {
        var behavior = behaviorsList[1];
        this.SetBehavior(behavior);
    }
}
