using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerState player;
    [SerializeField] private SceneManagement sceneManagement;
    [SerializeField] private CameraMovement cameraMovement;
    private float delay;
    private void OnTriggerEnter(Collider other)
    {
        float speed = player.Speed;
        if (speed>7.5f&&!other.CompareTag("FuelBoost")&&!other.CompareTag("Player"))
        {
            delay = 0.1f * speed;
            player.isBlown = true;
        }
        StartCoroutine(cameraMovement.Shake(0.1f*speed, speed*(player.isBlown ? 1.5f : 1f)));
        player.IsLanded = other.name == "PlatformFinal";
    }

    private void Update()
    {
        if (player.isBlown)
        {
            if (delay > 0f)
                delay -= Time.deltaTime;
            else
                sceneManagement.SceneRestart();
        }
    }
}
