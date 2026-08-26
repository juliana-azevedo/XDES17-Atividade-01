using UnityEngine;

public class Shredder : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    // other é a outra referencia
    // ele identifica outro item que contem collider
    //print(other.gameObject.name);
    
    // a ideia é subir na arvore do objeto com collider para poder destroir o item por completo de sua hierarquia
    Destroy(other.transform.parent.gameObject);
  }
}
