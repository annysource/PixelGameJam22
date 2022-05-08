using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformTerra, platformFloresta;
   
    public GameObject playerDoodler;
    public int level;
    public int platformCount = 10;

    void Start()
    {
        platformTerra.SetActive(false);
        platformFloresta.SetActive(false);
        // platform.SetActive(false);



    }
    void Update()
    {
        IdentificaLevel();
        //Debug.Log(playerDoodler.transform.position.y);
    }

    void IdentificaLevel()//1, 2, 3, 4 e final
    {
        
        if (playerDoodler.transform.position.y <= 12)
        {//verifica se level esta construido, level =1
            level = 1;
            Debug.Log("Level Terra Ativo na posicao "+ playerDoodler.transform.position.y);
        } else if (playerDoodler.transform.position.y <= 22)
        {
            level = 2;
            Debug.Log("Level Floresta Ativo na posicao " + playerDoodler.transform.position.y);
        }
        ConstroiLevel();
    }
    void ConstroiLevel()
    {
        if (level == 1)
        {
          if(platformTerra.activeSelf == true)
            {
                Debug.Log("Ja tem plataforma né galera");
            }
            else
            {
                Debug.Log("Bota Plataforma caralhooo");
                platformTerra.SetActive(true);
                Vector3 spawnPosition = new Vector3();
                //socorro deus
                for (int i = 0; i < platformCount; i++)
                {
                    spawnPosition.y += Random.Range(.5f, 2f);
                    spawnPosition.x = Random.Range(-2f, 2f);
                    Instantiate(platformTerra, spawnPosition, Quaternion.identity);
                }
            }
           

        }
        else if(level == 2)
        {
            if (platformFloresta.activeSelf == true)
            {
                Debug.Log("Ja tem plataforma no level 2 galera");
            }
            else
            {
                Debug.Log("Bota Plataforma nessa bostaaaa");
                platformFloresta.SetActive(true);
                Vector3 spawnPosition = playerDoodler.transform.position;
                //socorro deus
                for (int i = 0; i < platformCount; i++)
                {
                    spawnPosition.y += Random.Range(.5f, 2f);
                    spawnPosition.x = Random.Range(-2f, 2f);
                    Instantiate(platformFloresta, spawnPosition, Quaternion.identity);
                }
                
            }
        }
    }

   

   


 
}
