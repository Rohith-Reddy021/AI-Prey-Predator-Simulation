using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;

[Action("CustomActions/NightAction")]
public class NightAct : GOAction
{
    public override void OnStart()
    {
        gameObject.GetComponent<BehaviorExecutor>().paused=true;
        gameObject.GetComponent<DeerManager>().Night();
    }
}
