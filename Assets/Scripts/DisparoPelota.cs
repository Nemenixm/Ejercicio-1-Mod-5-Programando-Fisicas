using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoPelota : MonoBehaviour
{
    public Transform spawner;
    public Rigidbody blueBallPrefab;
    public Rigidbody redBallPrefab;
    public float fuerzaDisparo = 30f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (GameManager.Instance == null) return;
            if (!GameManager.Instance.ConsumirPelota()) return;

            Rigidbody prefabElegido = (Random.value < 0.5f) ? blueBallPrefab : redBallPrefab;
            Rigidbody nuevaPelota = Instantiate(prefabElegido, spawner.position, spawner.rotation);

            nuevaPelota.AddForce(spawner.forward * fuerzaDisparo, ForceMode.Impulse);
        }
    }
}