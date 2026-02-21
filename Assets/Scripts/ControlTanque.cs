using UnityEngine;
using UnityEngine.InputSystem;

public class ControlTanque : MonoBehaviour
{
    public Transform tanque;   // izquierda / derecha
    public Transform cañon;    // arriba / abajo

    public float velocidadHorizontal = 90f;
    public float velocidadVertical = 60f;

    public float limiteMin = -10f;
    public float limiteMax = 35f;

    float rotacionActual;

    void Start()
    {
        rotacionActual = cañon.localEulerAngles.x;

        if (rotacionActual > 180f)
            rotacionActual -= 360f;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // A / D
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed) horizontal = -1f;
        if (Keyboard.current.dKey.isPressed) horizontal = 1f;

        tanque.Rotate(0f, horizontal * velocidadHorizontal * Time.deltaTime, 0f);

        // W / S
        float vertical = 0f;
        if (Keyboard.current.wKey.isPressed) vertical = 1f;
        if (Keyboard.current.sKey.isPressed) vertical = -1f;

        rotacionActual += vertical * velocidadVertical * Time.deltaTime;
        rotacionActual = Mathf.Clamp(rotacionActual, limiteMin, limiteMax);

        Vector3 angulos = cañon.localEulerAngles;
        angulos.x = rotacionActual;
        cañon.localEulerAngles = angulos;
    }
}