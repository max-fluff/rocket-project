using UnityEngine;

public class FuelBoost : MonoBehaviour
{
    [SerializeField] private PlayerState player;
    [SerializeField] private float amount=5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "ColliderSingle" && other.gameObject.name != "ColliderDouble") return;
        player.DrainFuel(-amount);
        gameObject.SetActive(false);
    }
}
