using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;
using BBUnity.Actions;
using System.Collections.Generic;

[Action("CustomActions/SetDestination")]
public class SetDestination : GOAction
{
    Vector3 destination;

    public override void OnStart()
    {
        NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();

            if (gameObject.GetComponent<DeerManager>().Wander)
            { 
                List<GameObject> areas = gameObject.GetComponent<DeerManager>().GetNavMeshAreas();

                if (areas.Count > 0)
                {
                    GameObject selectedArea = areas[Random.Range(0, areas.Count)];
                    destination = new Vector3(
                        Random.Range(-selectedArea.transform.localScale.x * 1000, selectedArea.transform.localScale.x * 1000),
                        0,
                        Random.Range(-selectedArea.transform.localScale.z * 1000, selectedArea.transform.localScale.z * 1000)
                    );
                    agent.SetDestination(destination);
                }
                gameObject.GetComponent<DeerManager>().destination();
        }
    }
}
