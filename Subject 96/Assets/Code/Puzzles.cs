using UnityEngine;

public class Puzzles : MonoBehaviour
{
    bool canPullLever;
    public GameObject lever;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(canPullLever && Input.GetButtonDown("Fire1"))
        {
            lever.transform.rotation = Quaternion.Euler(0f, 0f, -146.263f);
            return; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever"))
        {
            canPullLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lever"))
        {
            canPullLever = false;
        }
    }
}
