using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("Configurações do Puzzle")]
    public float tempoLimite = 3.0f; // Tempo em segundos para ir de uma a outra
    public GameObject moedaRecompensa; // Moeda que vai aparecer

    [Header("Plataformas do Puzzle")]
    public PuzzlePlatform plataforma1;
    public PuzzlePlatform plataforma2;

    private int plataformaAtiva = 0; // 0 = nenhuma, 1 = pisou na primeira
    private float timer = 0f;

    void Start()
    {
        if (moedaRecompensa != null)
        {
            moedaRecompensa.SetActive(false); // Esconde a moeda no início
        }
        ResetarPuzzle();
    }

    void Update()
    {
        // Se a primeira plataforma foi ativada, roda o timer
        if (plataformaAtiva == 1)
        {
            timer += Time.deltaTime;
            if (timer >= tempoLimite)
            {
                ResetarPuzzle();
                Debug.Log("Tempo esgotado! Puzzle resetado.");
            }
        }
    }

    public void PisarNaPlataforma(int idPlataforma)
    {
        if (idPlataforma == 1 && plataformaAtiva == 0)
        {
            plataformaAtiva = 1;
            timer = 0f;
            if (plataforma1 != null)
            {
                plataforma1.AtivarPlataforma();
            }
            Debug.Log("Plataforma 1 ativada! Corra para a plataforma 2!");
        }
        else if (idPlataforma == 2 && plataformaAtiva == 1)
        {
            if (plataforma2 != null)
            {
                plataforma2.AtivarPlataforma();
            }
            CompletarPuzzle();
        }
    }

    private void CompletarPuzzle()
    {
        plataformaAtiva = 3; // Estado de puzzle resolvido
        if (moedaRecompensa != null)
        {
            moedaRecompensa.SetActive(true); // Faz a moeda aparecer
        }
        Debug.Log("Puzzle concluído com sucesso! Moeda liberada!");

        // Agenda o reset das plataformas após 5 segundos
        Invoke(nameof(ResetarPuzzle), 5f);
    }

    private void ResetarPuzzle()
    {
        plataformaAtiva = 0;
        timer = 0f;
        
        if (plataforma1 != null) plataforma1.ResetarPlataforma();
        if (plataforma2 != null) plataforma2.ResetarPlataforma();
    }
}
