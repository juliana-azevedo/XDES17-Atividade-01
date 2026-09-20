using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Timers;

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
    
    
    // VIDA
    [SerializeField] Slider VidaSlider;
    float vida;
    
    [SerializeField] private GameObject explosionPrefab; 
    
    [SerializeField] AudioClip audioClip;
  

    
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

    void OnTriggerEnter2D(Collider2D other)
    {
        vida += 0.2f;
        if (vida >= 1) {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                
                Destroy(explosion, 0.5f);
                
                Invoke(nameof(AbrirGameOver), 0.3f);
        }
        else
        {
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                
                Destroy(explosion, 0.5f);
                
                VidaSlider.value = vida;
            }
        }
        
    }
    
    void AbrirGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
        
}