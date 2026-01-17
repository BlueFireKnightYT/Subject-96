using UnityEngine;
using Unity.Cinemachine;
using System.Collections;
public class CameraFocusOnRock : MonoBehaviour
{
    public CinemachineCamera cam;
    public float targetLens = 9f;
    public float originalLens = 7f;
    public Vector3 targetOffset;
    public Vector3 originalOffset;
    public float duration = 1.5f;

    public void TriggerZoom()
    {
        StartCoroutine(ZoomRoutine());
    }

    IEnumerator ZoomRoutine()
    {
        
        float elapsed = 0;
        while (elapsed < duration)
        {
            cam.Lens.OrthographicSize = Mathf.Lerp(originalLens, targetLens, elapsed / duration);
            var followComponent = cam.GetComponent<CinemachineFollow>();
            followComponent.FollowOffset = Vector3.Lerp(originalOffset, targetOffset, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); 

        
        elapsed = 0;
        while (elapsed < duration)
        {
            cam.Lens.OrthographicSize = Mathf.Lerp(targetLens, originalLens, elapsed / duration);
            var followComponent = cam.GetComponent<CinemachineFollow>();
            followComponent.FollowOffset = Vector3.Lerp(targetOffset, originalOffset, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            TriggerZoom();
        }
    }
}
