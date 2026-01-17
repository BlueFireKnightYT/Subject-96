using UnityEngine;

public class Transparency : MonoBehaviour
{
    private SpriteRenderer sprRen;
    public Color Entercolor;
    public Color Exitcolor;
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
            sprRen.color = Entercolor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprRen.color = Exitcolor;
        }
    }
}
