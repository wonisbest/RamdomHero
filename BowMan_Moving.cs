using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMan_Moving : MonoBehaviour
{
    public float speed = 2.5f;
    public float Player_HP = 100;
    public float AD = 2;
    public bool JUMP = false;
    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform>();

    }
    void Update()
    {
        move();

        death();

    }

    void death()
    {
        if (Player_HP <= 0)
        {
            Destroy(gameObject);
            panel();
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            if (this.transform.position.x < 10)
            {
                this.transform.position += new Vector3(0.02f * speed, 0f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x > -9.5)
            {
                this.transform.position -= new Vector3(0.02f * speed, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (JUMP == true)
            {
                JUMP = false;
                StartCoroutine(Jump());

            }
        }

    }

    IEnumerator Jump()
    {

        for (int i = 0; i < 30; i++)
        {
            this.transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.012f);
            //점프 높이 = 
        }

        for (int i = 0; i < 30; i++)
        {
            this.transform.position -= new Vector3(0, 0.1f, 0);

            yield return new WaitForSeconds(0.012f);

        }

        JUMP = true;

    }
    public void panel()
    {
        GameObject.FindGameObjectWithTag("Finish").SetActive(true);
    }
}
