using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Attack : MonoBehaviour
{
    public bool Attacking = false;
    public float speed = 5f;

    public float AD = 15;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            
           
        }
    }

    void Attack()
    {
        if (Attacking == false)
        {
            Attacking = true;
            this.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(Attack_rotation());
            Debug.Log("Space");
            
        }
        
    }

    IEnumerator Attack_rotation()
    {
        
        for (int i =0; i<15; i++)
        {
            transform.Rotate(0, 0, -6);            
            yield return new WaitForSeconds(0.000001f) ;
                       
        }
        this.GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i <15; i++)
        {
            transform.Rotate(0, 0, +6);

            yield return new WaitForSeconds(0.02f);

        }
        Attacking = false;
        
    }

}
