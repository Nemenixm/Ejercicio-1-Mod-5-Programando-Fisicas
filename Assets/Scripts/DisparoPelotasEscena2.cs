using UnityEngine;
using UnityEngine.InputSystem;

public class DisparoPelotaEscena2 : MonoBehaviour
{
    public Transform spawner;
    public Rigidbody pelotaPrefab;   
    public float fuerzaDisparo = 15f;

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (GameManager.Instance == null) return;

           
            if (!GameManager.Instance.ConsumirTotal()) return;

            Rigidbody nuevaPelota = Instantiate(pelotaPrefab, spawner.position, spawner.rotation);
            nuevaPelota.AddForce(spawner.forward * fuerzaDisparo, ForceMode.Impulse);
        }
    }
}