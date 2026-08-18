using UnityEngine;

public class Municao : MonoBehaviour
{ 
    private Rigidbody2D _rb;
    float ySpeed = 5;

    void Awake()
    {
        // referência para o corpo rigido
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // Aplica a força uma vez só no corpo rígido
        _rb.AddForceY(ySpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
