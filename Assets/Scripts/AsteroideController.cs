using UnityEngine;

public class AsteroideController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speedY = 4f;
    [SerializeField] private float life = 100f;
    [SerializeField] private float damage = 50f;
    
    // Arraste o Prefab da explosão aqui pelo Inspector
    [SerializeField] private GameObject explosionPrefab; 
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0, -speedY), ForceMode2D.Impulse);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Garante que só reage a projéteis/munição (opcional, via Tag)
        // if (!other.CompareTag("Bullet")) return;

        if (other.transform.parent.name == "Shredder-Asteroide")
        {
            return;
        }

        // Destroi o projétil que colidiu
        Destroy(other.transform.parent != null ? other.transform.parent.gameObject : other.gameObject);

        // Aplica dano
        life -= damage;
        
        if (life <= 0)
        {
            // 1. Instancia o prefab de explosão na mesma posição e rotação do asteroide
            if (explosionPrefab != null)
            {
                print(explosionPrefab);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                
                // 2. Destroi o objeto de explosão após o tempo da animação (ex: 0.5s)
                Destroy(explosion, 0.5f);
            }

            // 3. Destroi o asteroide imediatamente
            Destroy(gameObject);
        }
    }
}