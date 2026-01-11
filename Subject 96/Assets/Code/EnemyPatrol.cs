using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA, pointB;
    private float speed = 4f;
    public Transform currentPoint;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = pointA.transform.position;
        currentPoint = pointB.transform;
    }



    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            currentPoint = currentPoint == pointA.transform
                ? pointB.transform
                : pointA.transform;
        }

        float dir = currentPoint == pointB.transform ? 1 : -1;
        rb2d.linearVelocity = new Vector2(dir * speed, rb2d.linearVelocity.y);
    }

}

