using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] public PlayerState player;
    public SceneManagement sceneManagement;

    private void OnTriggerEnter(Collider other)
    {
        if (player.Speed>10)
        {
            sceneManagement.SceneRestart();
            return;
        }
        player.IsLanded = other.name == "PlatformFinal";
    }
}
