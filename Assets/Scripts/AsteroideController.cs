using UnityEngine;

public class AsteroideController : MonoBehaviour
{
    Rigidbody2D _rb;
    float speedY = 4;
    Animator _animator;
    
    void Awake()
    {
        _rb =  GetComponent<Rigidbody2D>();
        _rb.AddForceY(-speedY, ForceMode2D.Impulse);
        
        // Busca a referência do Animator
        _animator = GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Liga o componente Animator para tocar a explosão
        _animator.enabled = true;
        
        // Destroi a munição
        Destroy(other.transform.parent.gameObject);

        // O método Destroy recebe o parâmetro de tempo para dar tempo de ver a explosão antes de o objeto sumir
        Destroy(gameObject, 0.5f); 
    }
    
}
