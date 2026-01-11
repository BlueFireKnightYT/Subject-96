using UnityEngine;
using System.Collections;

public class PlayerVault : MonoBehaviour
{
    
    public bool VaultDetected;
    [SerializeField] private bool isVaulting;
    [SerializeField] private LayerMask VaultLayer;
    [SerializeField] private Rigidbody2D rb2d;
    public AnimationCurve vaultCurve;
    public BoxCollider2D bc2d;


    public Vector2 startPos;
    public Vector2 endPos;

    void Start()
    {

    }


    void Update()
    {
       
        

        if (Input.GetKeyDown(KeyCode.G) && VaultDetected && !isVaulting)
        {
            float direction = transform.localScale.x > 0 ? 2 : -2;
            Vector2 targetPoint = new Vector2(transform.position.x + (2.0f * direction), transform.position.y);
            StartCoroutine(VaultRoutine(targetPoint, 0.5f));
            Debug.Log("Kutas");
        }
    }

    IEnumerator VaultRoutine(Vector2 targetPos, float duration)
    {
        isVaulting = true;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.linearVelocity = Vector2.zero;

        Vector2 startPos = transform.position;
        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime / duration;
            float x = Mathf.Lerp(startPos.x, targetPos.x, time);
            float y = Mathf.Lerp(startPos.y, targetPos.y, time) + vaultCurve.Evaluate(time);
            transform.position = new Vector2(x, y);
            bc2d.enabled = false;
            yield return null;
        }

        rb2d.bodyType = RigidbodyType2D.Dynamic;
        isVaulting = false;
        bc2d.enabled = true;


    }

    

}
