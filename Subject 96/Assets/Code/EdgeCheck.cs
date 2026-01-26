using UnityEngine;

public class EdgeCheck : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private bool VaultDetected;
    [SerializeField] private LayerMask GroundLayer;
    public Transform checkerPos;
    public Player player;

    
    void Update()
    {
        player.EdgeDetected = Physics2D.OverlapCircle(checkerPos.position, radius, GroundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkerPos.position, radius);
    }
}
