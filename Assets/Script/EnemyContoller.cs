using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContoller : MonoBehaviour {

    public float restTimer = 3f;
    public float restTimerCountdown;
    public float lookRadius = 2000f;
    public float attackRadius = 30f;
    public Animator cyclopsAnimator;

    public GameObject EyeSphere;
    public CapsuleCollider EyeSphereCollider;
    public BoxCollider HitScanCollider;

    private Transform target;
    private NavMeshAgent agent;

    private bool isMoving;
    

	// Use this for initialization
	void Start () {
        cyclopsAnimator = GetComponent<Animator>();
        EyeSphereCollider = EyeSphere.GetComponent<CapsuleCollider>();
        HitScanCollider = GameObject.Find("HitScan").GetComponent<BoxCollider>();


        SetIdleBoolVariable();
        restTimerCountdown = restTimer;


        target = GameObject.Find("FPSController").transform;
        agent = GetComponent<NavMeshAgent>();
        
		
	}

    public void SetIdleBoolVariable() {
        HitScanCollider.enabled = false;
        EyeSphereCollider.enabled = true;
        cyclopsAnimator.SetBool("IsMoving", false);
        cyclopsAnimator.SetBool("Resting", true);
    }

    public void setTime() {
        restTimer = restTimerCountdown;
    }
    void SetRunBoolVariable()
    {
        HitScanCollider.enabled = false;
        EyeSphereCollider.enabled = false;
        cyclopsAnimator.SetBool("IsMoving", true);
        cyclopsAnimator.SetBool("WithinAttackRange", false);
        cyclopsAnimator.SetBool("Resting", false);
    }
    void SetAttack1BoolVariable()
    {
        EyeSphereCollider.enabled = false;
        cyclopsAnimator.SetBool("IsMoving", false);
        cyclopsAnimator.SetBool("WithinAttackRange", true);
        cyclopsAnimator.SetBool("Resting", false);
    }

    // Update is called once per frame
    void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        //Debug.Log(distance);

        if (restTimer <= 0)
        {
            
            if (distance <= attackRadius)
            {
                SetAttack1BoolVariable();
                agent.isStopped = true;
            }
            else if (distance <= lookRadius)
            {
                agent.isStopped = false;
                SetRunBoolVariable();
                agent.SetDestination(target.transform.position);
            }
        }
        else {
            SetIdleBoolVariable();
            Vector3 newDir = Vector3.RotateTowards(transform.forward, target.transform.position, 5, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            agent.isStopped = true;
            restTimer -= Time.deltaTime;
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //Placeholder functions for Animation events
    void Hit()
    {
        StartCoroutine(GameObject.Find("FPSController").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().CameraShake());
        HitScanCollider.enabled = true;

    }

    void FootR()
    {
    }

    void FootL()
    {
    }
}
