using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI (un solo texto)")]
    public TextMeshProUGUI textoUI; // TU Text (TMP) del Canvas

    [Header("Valores")]
    public int pelotasIniciales = 50;

    public int Restantes { get; private set; }
    public int Total { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        Restantes = pelotasIniciales;
        Total = 0;
        ActualizarUI();
    }

    public bool ConsumirPelota()
    {
        if (Restantes <= 0) return false;
        Restantes--;
        ActualizarUI();
        return true;
    }

    public void AplicarMultiplicador(int multiplicador)
    {
        Total += multiplicador;     // x2 suma 2, x4 suma 4, -1 resta 1
        if (Total < 0) Total = 0;   // opcional: evitar negativos
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textoUI != null)
            textoUI.text = $"Restantes: {Restantes}\nTotal: {Total}";
    }
}