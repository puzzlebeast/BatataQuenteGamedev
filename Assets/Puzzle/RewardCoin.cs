using UnityEngine;

public class RewardCoin : MonoBehaviour
{
    [Header("Configurações de Rotação")]
    [Tooltip("Velocidade de rotação em graus por segundo")]
    public float velocidadeRotacao = 50f;

    [Tooltip("Eixo de rotação (ex: 0,1,0 para Y | 1,0,0 para X | 0,0,1 para Z)")]
    public Vector3 eixoRotacao = Vector3.up;

    void Update()
    {
        // Rotaciona a moeda suavemente em torno do eixo configurado no Inspector
        transform.Rotate(eixoRotacao.normalized * velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta se o jogador encostou na moeda
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moeda coletada pelo jogador!");
            
            // Destrói a moeda da cena
            Destroy(gameObject);
        }
    }
}
