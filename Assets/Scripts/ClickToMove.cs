using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ClickToMove : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            // Checks if pointer is over an EventSystem object (part of the UI).
            if (EventSystem.current.IsPointerOverGameObject()) return;

            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }
        }
    }
}
