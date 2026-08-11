using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    Material mat; // para guardar o material
    [SerializeField] float speed; // aparece no editor do Unity para poder alterar a velocidade
    float offsetX; // para guardar a posição atual de Y

    void Awake()
    {
        // Pega o Material que está dentro do Renderer deste objeto
        mat = GetComponent<SpriteRenderer>().material;
    }
    
    // void Start()
    // {
    //     
    // }

    // Update is called once per frame
    void Update()
    {
        // Aumenta o valor do Y multiplicando pela velocidade e pelo tempo do frame
        offsetX += speed * Time.deltaTime; 
        // Aplica o valor no material
        mat.mainTextureOffset = new Vector2(offsetX, 0);
    }
}
