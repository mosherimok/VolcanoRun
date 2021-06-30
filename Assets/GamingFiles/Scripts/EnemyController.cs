using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public float shootRadius = 5f;
    public Transform target;
    NavMeshAgent agent;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 2f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string playerTag = "Player";

    public GameObject bulletPrefab;
    public Transform firePoint;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (target == null)
        {
            anim.SetBool("walking", false);
            anim.SetInteger("condition", 0);
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            if (anim.GetBool("shooting") == true)
            {
                agent.isStopped = true;
                return;
            }
            else
            {
                if (distance >= shootRadius)
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.position);
                    anim.SetInteger("condition", 1);
                    anim.SetBool("walking", true);
                }
                
                if (distance <= shootRadius)
                {
                    if (anim.GetBool("walking") == true)
                    {
                        anim.SetBool("walking", false);
                        anim.SetInteger("condition", 0);
                    }
                    else
                    {
                        if (fireCountdown <= 0)
                        {
                            Shoot();
                            fireCountdown = 1f / fireRate;
                        }

                        fireCountdown -= Time.deltaTime;
                    }
                }
            }
        }
        else
        {
            anim.SetInteger("condition", 0);
            anim.SetBool("walking", false);
        }
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGO.GetComponent<BulletScript>();

        StartCoroutine("ShootingRoutine");

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }

    IEnumerator ShootingRoutine()
    {
        anim.SetBool("shooting", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("shooting", false);
    }

    void OnDrawGizmosSelected()
    {
        // trigger range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        // shoot range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
    }
}
