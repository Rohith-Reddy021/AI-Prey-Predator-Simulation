using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;
using BBUnity.Actions;

[Action("CustomActions/WaterAction")]
public class DWaterAct : GOAction
{
    NavMeshAgent agent;
    private Vector3 lastWaterPosition;

    public override void OnStart()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        Vector3 currentWaterPosition = gameObject.GetComponent<DeerManager>().WaterCollectables[0].transform.position;

        if (lastWaterPosition != currentWaterPosition)
        {
            lastWaterPosition = currentWaterPosition;
            agent.SetDestination(lastWaterPosition);
        }

        if (gameObject.GetComponent<DeerManager>().checkWaterDistance())
        {
            
        }
    }
}
