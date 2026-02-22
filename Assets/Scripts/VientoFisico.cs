using UnityEngine;

public class VientoFisico : MonoBehaviour
{
    public Vector3 direccion = Vector3.right;

    public float fuerzaMin = 1f;
    public float fuerzaMax = 50f;
    public float velocidadCambio = 1f; 

    float fuerzaActual;

    [System.Obsolete]
    void FixedUpdate()
    {
        
        fuerzaActual = fuerzaMin + Mathf.PingPong(Time.time * velocidadCambio, fuerzaMax - fuerzaMin);

        foreach (var rb in FindObjectsOfType<Rigidbody>())
        {
            if (rb.CompareTag("Ball"))
            {
                rb.AddForce(direccion.normalized * fuerzaActual, ForceMode.Force);
            }
        }
    }
}