using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private Vector2 boxSize = new Vector2(3f, 1.5f);
    [SerializeField] private Vector2 boxOffset = new Vector2(1.5f, 0f);
    public LayerMask playerLayer;
    private bool isFacingRight = true; 
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isFacingRight = !isFacingRight;

            boxOffset = isFacingRight
                ? new Vector2(3.13f, 0.03f)
                : new Vector2(-3.13f, 0.03f);
        }

        if (SeePlayer())
        {
            Debug.Log("Player Spotted");
        }
    }

    private bool SeePlayer()
    {
        Vector2 origin = (Vector2)transform.position + boxOffset;
        Collider2D player = Physics2D.OverlapBox(origin, boxSize, 0f, playerLayer);
        if (player == null)
        {
            return false;
        }
        Vector2 dir = (player.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance, obstacleLayer | playerLayer);
        return hit.collider != null && hit.collider.CompareTag("Player");
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = (Vector2)transform.position + boxOffset;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(origin, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, origin);
    }
}
