using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject seekMe;

	private NavMeshAgent agent;
	private Vector3 target;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		target = seekMe.transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination(target);
	}
}
