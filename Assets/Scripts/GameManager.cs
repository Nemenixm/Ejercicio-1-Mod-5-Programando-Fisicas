using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Escena 1 (opcional)")]
    public TextMeshProUGUI textoUI; 

    [Header("Valores iniciales")]
    public int pelotasIniciales = 50;

    public int Restantes { get; private set; }
    public int Total { get; private set; }

    [Header("Escena 2")]
    public string escena2 = "Derrumbe";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Restantes = pelotasIniciales;
        Total = 0;
        ActualizarUI();
    }

    // Escena 1
    public bool ConsumirRestante()
    {
        if (Restantes <= 0) return false;

        Restantes--;
        ActualizarUI();

        if (Restantes == 0)
            SceneManager.LoadScene(escena2);

        return true;
    }

    
    public void AplicarMultiplicador(int multiplicador)
    {
        Total += multiplicador;
        if (Total < 0) Total = 0;
        ActualizarUI();
    }

    // Escena 2
    public bool ConsumirTotal()
    {
        if (Total <= 0) return false;
        Total--;
        return true;
    }

    void ActualizarUI()
    {
        if (textoUI != null)
            textoUI.text = $"Restantes: {Restantes}\nTotal: {Total}";
    }
}