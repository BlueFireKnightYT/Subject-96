using UnityEngine;

public class Transparency : MonoBehaviour
{
    private SpriteRenderer sprRen;
    void Start()
    {
        sprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprRen.color = new Color(1f, 1f, 1f, 0.53f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprRen.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
