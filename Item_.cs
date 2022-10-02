using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_ : MonoBehaviour
{
    public bool Once = true ;
    public bool Gem_1 = false;
    public bool Gem_2 = false;
    public bool Gem_3 = false;
    public bool Gem_4 = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
        Once = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("아이템 획득");
            if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().speed += 0.3f;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().speed += 0.15f;
            }
            Destroy(gameObject);
            if (Gem_1 == true) {
                if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().AD += 5;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().AD += 2;
                }
            }
            else if (Gem_2 == true)
            {
                if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().AD += 8;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().AD += 4;
                }
            }
            if (Gem_3 == true)
            {
                if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().AD += 10;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().AD += 6;
                }
            }
            if (Gem_4 == true)
            {
                if (GameObject.Find("Job_disable").GetComponent<Random_Job>().ran == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().AD += 15;
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().AD += 10;
                }
            }
            
        }
     }

    IEnumerator Jump()
    {

        for (int i = 0; i < 20; i++)
        {
            this.transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.001f);
            
        }

        for (int i = 0; i < 20; i++)
        {
            this.transform.position -= new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
