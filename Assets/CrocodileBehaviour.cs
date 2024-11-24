using UnityEngine;
using UnityEngine.AI;

public class CrocodileBehavior : MonoBehaviour
{
    public NavMeshAgent agent;               // The NavMeshAgent component
    public Transform player;                 // Reference to the player
    public float detectionRadius = 10f;      // Radius to detect the player in water
    public Transform waterPlane;             // Reference to the water plane
    public float roamRange = 20f;            // Range within which the crocodile roams
    public float damageInterval = 1f;        // Time between damage ticks
    public int damageAmount = 10;            // Damage dealt per tick

    private Vector3 roamTarget;              // Target point for roaming
    private bool isPlayerInWater = false;    // Tracks if the player is in water
    private float lastDamageTime = 0f;       // Time of last damage tick

    void Start()
    {
        SetRandomRoamTarget();
    }

    void Update()
    {
        if (isPlayerInWater)
        {
            // Follow the player
            agent.SetDestination(player.position);
            DealDamageToPlayer();
        }
        else
        {
            // Roam around randomly
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                SetRandomRoamTarget();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            isPlayerInWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            isPlayerInWater = false;
            SetRandomRoamTarget(); // Resume roaming when player leaves water
        }
    }

    void SetRandomRoamTarget()
    {
        if (waterPlane == null) return;

        Vector3 randomPoint = waterPlane.position +
            new Vector3(Random.Range(-roamRange, roamRange), 0, Random.Range(-roamRange, roamRange));

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, roamRange, NavMesh.AllAreas))
        {
            roamTarget = hit.position;
            agent.SetDestination(roamTarget);
        }
    }

    void DealDamageToPlayer()
    {
        if (Time.time - lastDamageTime >= damageInterval)
        {
            lastDamageTime = Time.time;

            // Implement health system or call a damage method on the player
            Debug.Log("Player takes damage: " + damageAmount);
            // Example: player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
