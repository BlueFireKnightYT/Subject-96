using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float breakForce = 40f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float force = collision.relativeVelocity.magnitude;
        Debug.Log("Impact force: " + force);

        if (force > breakForce)
        {
            Destroy(gameObject);
        }
    }
}
