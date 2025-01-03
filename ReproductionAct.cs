using UnityEngine;
using Pada1.BBCore;
using BBUnity.Actions;

[Action("CustomActions/ReproductionAction")]
public class ReproductionAct : GOAction
{
    public override void OnStart()
    {
        if (gameObject.GetComponent<DeerManager>().isReproductionInProgress==false){
        gameObject.GetComponent<DeerManager>().isReproductionInProgress = true;
        gameObject.GetComponent<DeerManager>().Reproduction();
    }
    }
}
