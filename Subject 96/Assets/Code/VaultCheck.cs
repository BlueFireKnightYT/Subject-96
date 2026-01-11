using UnityEngine;
using System.Collections;

public class VaultCheck : MonoBehaviour
{
    [SerializeField]private float radius;
    [SerializeField]private bool VaultDetected;
    [SerializeField] private LayerMask VaultLayer;
    public PlayerVault player;
    

   
    void Start()
    {
           
    }

    
    void Update()
    {
        player.VaultDetected = Physics2D.OverlapCircle(transform.position, radius, VaultLayer);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
