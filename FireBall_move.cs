using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall_move : MonoBehaviour
{
    public float FireBall_Damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if(this.CompareTag("Sword")== true)
        {
            transform.Rotate(0, 0, +90);
        }

        if (this.CompareTag("Redball"))
        {
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > -10)
        {
            if (this.CompareTag("IceBall") || this.CompareTag("Redball"))
            {
                this.transform.position += new Vector3(-0.12f, 0f, 0f);
               
            }

            
            else { 
            this.transform.position += new Vector3(-0.06f, 0f, 0f);
            }
        }
        else if (this.transform.position.x <= -10)
        { 
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("뜨겁지 이놈");
            if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().Player_HP -= FireBall_Damage;
                
            }

            else { 
            GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().Player_HP -= FireBall_Damage;
            
            }
            
        }
      


    }

   
}
