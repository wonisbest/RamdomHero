using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighning : MonoBehaviour
{
    // Start is called before the first frame update
    public float LIghtning_Damage = 2;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (this.transform.position.x < 11)
        {
            this.transform.position += new Vector3(0.2f, 0f, 0f);
        }
        else if (this.transform.position.x >= 7)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ex_Boss") || collision.gameObject.CompareTag("Boss") )
        {
            Debug.Log("쮜륏쓰~");
            
            Destroy(gameObject);
        }



    }
}
