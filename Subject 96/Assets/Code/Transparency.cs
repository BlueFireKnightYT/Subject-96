using UnityEngine;

public class Transparency : MonoBehaviour
{
    private SpriteRenderer sprRen;
    Color baseColor;
    void Start()
    {
        sprRen = GetComponent<SpriteRenderer>();
        baseColor = sprRen.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color tempColor = sprRen.color;
            tempColor.a = 0.5f;
            sprRen.color = tempColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprRen.color = baseColor;
        }
    }
}
