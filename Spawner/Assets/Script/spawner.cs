using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float radio;
    private float respawn;
    public float timeRespawn;
    public GameObject colibre;
    public Transform Player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        respawn= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.position)<radio)
        {
            gameObject.GetComponent<Animator>().SetBool("Create", true);
            if (timeRespawn <= 0)
            {
                Instantiate(colibre, transform.position, Quaternion.identity);
                gameObject.GetComponent<Animator>().SetBool("Create", false);
                respawn++;
                timeRespawn = respawn;
                if (respawn >= 5)
                {
                    respawn = 3;
                        
                }
                else
                {
                    respawn = 0;
                        
                }

            }
            else
            {
                timeRespawn -= Time.deltaTime;

            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Create", false);
            respawn =0;
        }
       
    }
}
