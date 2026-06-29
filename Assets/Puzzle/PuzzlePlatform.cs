using UnityEngine;

public class PuzzlePlatform : MonoBehaviour
{
    [Header("Configuração da Plataforma")]
    [Tooltip("Defina como 1 para a primeira plataforma e 2 para a segunda")]
    public int idPlataforma; 
    
    public PuzzleManager gerenciador; // Referência ao gerenciador do puzzle

    [Header("Materiais de Estado")]
    public Material materialInativo; // Arraste o material 'not_active' aqui
    public Material materialAtivo;   // Arraste o material 'active' aqui

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        ResetarPlataforma();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no Trigger é o Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Confirmado: É o Player!");
            Debug.Log("O Jogador pisou na plataforma com ID: " + idPlataforma);

            if (gerenciador != null)
            {
                gerenciador.PisarNaPlataforma(idPlataforma);
            }
        }
    }

    public void AtivarPlataforma()
    {
        if (meshRenderer != null && materialAtivo != null)
        {
            meshRenderer.material = materialAtivo;
        }
    }

    public void ResetarPlataforma()
    {
        if (meshRenderer != null && materialInativo != null)
        {
            meshRenderer.material = materialInativo;
        }
    }
}
