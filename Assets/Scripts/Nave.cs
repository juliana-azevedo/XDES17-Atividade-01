using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{
    Rigidbody2D _rb; // pega a referencia do corpo rigido
    float xSpeed = 110f; // para colocar intensidade na movimentação
    float xDir; // as direções dado pelo usuário
    
    // todos os objetos sao game objetos, os atores em cena, e para mexer nesses objetos é preciso mexer na superclasse
    [SerializeField] GameObject municaoPrefebs;
    
    // Referência para o ponto de onde o tiro vai sair
    [SerializeField] Transform pontoDeTiro;
    
    // Taxa de Disparo
    float taxaDeDisparo = 0.2f;
    float proxDisparo = 0.5f;
    
    void Awake()
    {
        // seta as referencias
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // aplica força uma vez só
        _rb.AddForceX(xSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Movimentar()
    {
        // Aplicar o movimento no corpo rígido, a direção e a intensidade são atribuidas ao movimento
        _rb.linearVelocityX = xDir * xSpeed * Time.deltaTime;   
    }

    void FixedUpdate()
    {
        // onde ocorre as aplicações físicas
        Movimentar();
    }

    void OnMove(InputValue inputValue)
    {
        // Direção do movimento em x
        xDir = inputValue.Get<Vector2>().x;
        //xDir = inputValue.Get<Vector2>().x; // vale 0, 1 , -1
    }
    
    void OnAttack()
    {
        // gerar a munição
        // o que eu vou instanciar, onde, qual a rotação
        //Instantiate(municaoPrefebs, transform.position, Quaternion.identity);
        
        // Verifica se já passou tempo suficiente para atirar de novo
        if (Time.time >=  proxDisparo)
        {
            // Atualiza o tempo do próximo disparo permitido
            proxDisparo = Time.time + taxaDeDisparo;
            Instantiate(municaoPrefebs, pontoDeTiro.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("arma recarregando");
        }
    }
        
}
