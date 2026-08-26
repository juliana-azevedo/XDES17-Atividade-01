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
    float fireRate = 0.2f;
    float lastFire;
    bool isFiring;   
    
    void Awake()
    {
        // seta as referencias
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isFiring)
        {
            Atirar();
        }
    }
    void Movimentar()
    {
        if (transform.position.x <= -2.4f && xDir < 0)
        {
            _rb.linearVelocityX = 0;
        }
        else if (transform.position.x >= 2.4f && xDir > 0)
        {
            _rb.linearVelocityX = 0;
        }
        else
        {
            _rb.linearVelocityX = xDir * xSpeed *  Time.deltaTime;
        }
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

    void Atirar()
    {
        // gerar a munição
        // o que eu vou instanciar, onde, qual a rotação
        //Instantiate(municaoPrefebs, transform.position, Quaternion.identity);
        
        //Testar se pode atirar
        if (Time.time > lastFire + fireRate)
        {
            Instantiate(municaoPrefebs, transform.position, Quaternion.identity);
            lastFire = Time.time;
        }
    }
    
    void OnAttack()
    {
        // para ativar e desativar quando o botao é pressionado/ segurado e despressionado
        isFiring = !isFiring;
    }
        
}
