using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float monster_hp = 20;  
    public float Monster_Amor = 1;
    public float Monster_Attack = 5;
    public float Weapon_Info_Ad ;
    public float Monster_Speed = 0.01f;
    public float Monster_Back = 0.3f;
    public GameObject WinPanel;
    public bool FIRE = false;
    public float Fire_Timed = 5;
    public GameObject Fireball_prefab;
    GameObject Fireball_target;
    public bool Drop = false;
    public GameObject Drop_Item_prefab;
    GameObject Drop_Item_target;
    int rand_;
   
    public void WeaponAD()
    {
        Weapon_Info_Ad = GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<SwordMan_Moving>().AD;
        Weapon_Info_Ad = GameObject.Find("Character").transform.GetChild(1).gameObject.GetComponent<BowMan_Moving>().AD;
        Weapon_Info_Ad = GameObject.Find("Character").transform.GetChild(2).gameObject.GetComponent<BowMan_Moving>().AD; 
    }
   
    void Start()
    {
       WeaponAD();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MonsterDead();
        if(FIRE == true) 
        {
            FIRE = false;
            if (this.CompareTag("Enemy")) 
            { 
                StartCoroutine(Fireball());
            }
            else if (this.CompareTag("Ex_Boss") || this.CompareTag("Boss"))
            {
                StartCoroutine(Fireball_Boss());
            }
        }
    }

    private void Move()
    {
        if (this.transform.position.x > -10) 
        { 
            this.transform.position -= new Vector3(Monster_Speed, 0f, 0f);
        }
    }

    private void MonsterDead()
    {
        if (monster_hp <= 0)
        {
            Destroy(gameObject);
            DropItem();
            if (WinPanel.activeSelf == false)
            {
                WinPanel.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Hitted_from_Enemy_player());
            if (GameObject.Find("Job_disable").GetComponent<JOB>().ran == 0) 
            { 
            GameObject.FindGameObjectWithTag("Player").GetComponent<SwordMan_Moving>().Player_HP -= Monster_Attack;
            }
            else 
            { 
            GameObject.FindGameObjectWithTag("Player").GetComponent<BowMan_Moving>().Player_HP -= Monster_Attack;
            }
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            monster_hp -= Weapon_Info_Ad * Monster_Amor;
            StartCoroutine(Hitted_from_Enemy());
        }
        if (collision.gameObject.CompareTag("Arrow"))
        {
            monster_hp -= Weapon_Info_Ad * Monster_Amor;
            StartCoroutine(Hitted_from_Enemy());
            
        }
        if (collision.gameObject.CompareTag("LigtningBolt"))
        {
            monster_hp -= Weapon_Info_Ad * Monster_Amor;
            StartCoroutine(Hitted_from_Enemy());
            Destroy(collision.gameObject);
        }

    }
    IEnumerator Hitted_from_Enemy() //넉백
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(Monster_Back , 0, 0);
            yield return new WaitForSeconds(0.01f);
        } 
    }
    IEnumerator Hitted_from_Enemy_player() //넉백
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(Monster_Back * 1.5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Fireball()
    {
        yield return new WaitForSeconds(Fire_Timed);
        Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(Fire_Timed);
        FIRE = true;
    }
    IEnumerator Fireball_Boss()
    {
        yield return new WaitForSeconds(Fire_Timed);
        if (gameObject.CompareTag("Boss"))
        {
            rand_ = Random.Range(0, 4);
            if (rand_ == 0)
            {   //1.5가 없음
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -1.5f, this.transform.position.z), Quaternion.identity);
                //Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 0.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -0.5f, this.transform.position.z), Quaternion.identity);
            }
            else if (rand_ == 1)
            {   //0.5가 없음
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -1.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 1.5f, this.transform.position.z), Quaternion.identity);
                //Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -0.5f, this.transform.position.z), Quaternion.identity);
            }
            else if (rand_ == 2)
            {   // - 0.5가 없음
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                //Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -1.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 1.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -0.5f, this.transform.position.z), Quaternion.identity);
            }
            else if (rand_ == 3)
            {   //-.1.5가 없음
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 0.5f, this.transform.position.z), Quaternion.identity);
                //Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 1.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -0.5f, this.transform.position.z), Quaternion.identity);
            } 
        }
        else {
            rand_ = Random.Range(0, 3);
            if (rand_ == 0)
            {
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 0f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 2.5f, this.transform.position.z), Quaternion.identity);
            }
            else if (rand_ == 1)
            {
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 2.5f, this.transform.position.z), Quaternion.identity);
            }
            else if (rand_ == 2)
            {
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, -2.5f, this.transform.position.z), Quaternion.identity);
                Fireball_target = (GameObject)Instantiate(Fireball_prefab, new Vector3(this.transform.position.x + 0.1f, 0f, this.transform.position.z), Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(Fire_Timed);
        FIRE = true;
    }
    public void DropItem()
    {
        if(Drop == true)
        {
            Drop_Item_target = (GameObject)Instantiate(Drop_Item_prefab, new Vector3(this.transform.position.x, -2.5f, this.transform.position.z), Quaternion.identity);
        }
    }     
}