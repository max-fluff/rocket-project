using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -15);
    private Vector3 shakeOffset = new Vector3(0, 0, 0);
    private void Update()
    {
        transform.position = player.transform.position+offset+shakeOffset;
    }

    public IEnumerator Shake(float duration,float speed)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-0.01f, 0.01f)*speed;
            float y = Random.Range(-0.01f, 0.01f)*speed;
            shakeOffset = new Vector3(x, y, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
        shakeOffset = new Vector3(0,0,0);
    }
}
