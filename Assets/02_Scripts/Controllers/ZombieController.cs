using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    // 1. 타겟 지정
    // 2. 탐지 거리
    // 3. 공격 거리
    // 4. 상태 애니메이션 적용
    public Transform target;

    Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance > agent.stoppingDistance)
        {

        }
        
    }
}
