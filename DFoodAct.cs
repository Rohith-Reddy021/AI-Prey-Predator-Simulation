using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;
using BBUnity.Actions;
using System.Collections.Generic;

[Action("CustomActions/FoodAction")]
public class DFoodAct : GOAction
{
    private NavMeshAgent agent;
    private Vector3 lastWaterPosition;

    public override void OnStart()
    {

        agent = gameObject.GetComponent<NavMeshAgent>();
        if(gameObject.GetComponent<DeerManager>()!=null && gameObject.GetComponent<DeerManager>().FoodCollectables.Count>0){
        Vector3 currentWaterPosition = gameObject.GetComponent<DeerManager>().FoodCollectables[0].transform.position;
        
        if (lastWaterPosition != currentWaterPosition)
        {
            lastWaterPosition = currentWaterPosition;
            agent.SetDestination(lastWaterPosition);
        }

        if (gameObject.GetComponent<DeerManager>().checkDistance())
        {   
            GameObject.Destroy(gameObject.GetComponent<DeerManager>().FoodCollectables[0]);
        }
    }
    }
}
