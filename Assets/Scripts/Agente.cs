using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{
    public Transform objetivo;
    public NavMeshAgent perseguidor;

    // Update is called once per frame
    void Update()
    {
        perseguidor.destination = objetivo.position;
    }
}
