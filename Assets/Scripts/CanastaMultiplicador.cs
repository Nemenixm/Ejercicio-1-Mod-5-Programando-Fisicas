using UnityEngine;

public class CanastaMultiplicador : MonoBehaviour
{
    public int multiplicador = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        GameManager.Instance?.AplicarMultiplicador(multiplicador);
        Destroy(other.gameObject);
    }
}