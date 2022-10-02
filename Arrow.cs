using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Arrow_Damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (this.transform.position.x < 11)
        {
            this.transform.position += new Vector3(0.3f, 0f, 0f);
        }
        else if (this.transform.position.x >= 10.9)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ex_Boss") || collision.gameObject.CompareTag("Boss"))
        {
            Debug.Log("따갑지롱~");
            Destroy(gameObject);
        }



    }
}
