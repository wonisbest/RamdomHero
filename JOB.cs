using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JOB : MonoBehaviour
{
    public int job;
    private JOB instance ;
    bool job_disable = true;
    bool rand_job_once = true;
    public float attacking_n = 0;
    public int ran;
    bool job_var = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (job_var)
        {
                ran = Random.Range(0, 3);
                job_var = false;
        }
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
                job = ran;
        }

        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            if (GameObject.Find("Character").activeSelf == true)
            {
                if (job_disable)
                {
                    Job_selected();
                }
            }
        }
        

        if (SceneManager.GetActiveScene().name != "MainScene") { 
        if (job == 0)
        {
            if (attacking_n < GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<SwordMan_Moving>().AD)
            {
                attacking_n = GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<SwordMan_Moving>().AD;
            }
            else
            {
                GameObject.Find("Character").transform.GetChild(0).gameObject.GetComponent<SwordMan_Moving>().AD = attacking_n;
            }
        }
        else if (job == 1)
        {
            if (attacking_n < GameObject.Find("Character").transform.GetChild(1).gameObject.GetComponent<BowMan_Moving>().AD )
            {
                attacking_n = GameObject.Find("Character").transform.GetChild(1).gameObject.GetComponent<BowMan_Moving>().AD;
            }
            else
            {
                GameObject.Find("Character").transform.GetChild(1).gameObject.GetComponent<BowMan_Moving>().AD = attacking_n;
            }
        }
        else if (job == 2)
        {
            if (attacking_n < GameObject.Find("Character").transform.GetChild(2).gameObject.GetComponent<BowMan_Moving>().AD)
            {
                attacking_n = GameObject.Find("Character").transform.GetChild(2).gameObject.GetComponent<BowMan_Moving>().AD;
            }
            else
            {
                GameObject.Find("Character").transform.GetChild(2).gameObject.GetComponent<BowMan_Moving>().AD = attacking_n;
            }
        }
        }
    }

        


    

    

    public void Job_selected()
    {
        if (job == 0)
        {
            if (GameObject.Find("Character").transform.GetChild(1).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(1).gameObject.SetActive(false);
            }
            if (GameObject.Find("Character").transform.GetChild(2).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(2).gameObject.SetActive(false);
            }

        }

        if (job == 1)
        {
            if (GameObject.Find("Character").transform.GetChild(0).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(0).gameObject.SetActive(false);
            }
            if (GameObject.Find("Character").transform.GetChild(2).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(2).gameObject.SetActive(false);
            }

        }

        if (job == 2)
        {
            if (GameObject.Find("Character").transform.GetChild(1).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(1).gameObject.SetActive(false);
            }
            if (GameObject.Find("Character").transform.GetChild(0).gameObject.activeSelf == true)
            {
                GameObject.Find("Character").transform.GetChild(0).gameObject.SetActive(false);
            }


        }

    }
    public void Rand_Job()
    {
        if (ran == 0)
        {
            GameObject.Find("Magicain_Text").SetActive(false);
            GameObject.Find("BowMan_Text").SetActive(false);
            //검사되기
        }
        if (ran == 1)
        {
            GameObject.Find("SwordMan_Text").SetActive(false);
            GameObject.Find("Magicain_Text").SetActive(false);
            //궁수 되기
        }
        if (ran == 2)
        {
            GameObject.Find("SwordMan_Text").SetActive(false);
            GameObject.Find("BowMan_Text").SetActive(false);
            //마법사 되기
        }
    }
}
