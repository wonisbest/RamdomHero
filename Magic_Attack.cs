using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Attacking = false;
    public float speed = 5f;
    public float AD = 15;
    public GameObject Ligtning_prefab;
    GameObject Ligtning_target;
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

        for (int i = 0; i < 15; i++)
        {
            transform.Rotate(0, 0, +2);
            transform.position += new Vector3(0, 0.02f, 0);
            yield return new WaitForSeconds(0.000001f);

        }
        this.GetComponent<BoxCollider>().enabled = false;
        Ligtning_target = (GameObject)Instantiate(Ligtning_prefab, new Vector3(this.transform.position.x + 0.1f, this.transform.position.y + 2f, this.transform.position.z), Quaternion.identity);
        for (int i = 0; i < 15; i++)
        {
            transform.Rotate(0, 0, -2);
            transform.position += new Vector3(0, -0.02f, 0);
            yield return new WaitForSeconds(0.02f);

        }
        Attacking = false;

    }
}
