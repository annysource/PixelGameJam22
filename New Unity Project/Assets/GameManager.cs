using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platformTerra, platformFloresta;
   
    public GameObject playerDoodler;
    public int level;
    public int platformCount = 7;

    public Text capivarias;
    public int capivaraCount = 1;
    public GameObject capivaraAlone;
    public static int filhas = 0;
    public GameObject capivara1, capivara2, capivara3;
    public static bool vivo, ganhou, comparaPontos;
    public GameObject gameOver, vitoria, platformDefault;
  
    public Text fimdejogo;

    public float totalTime;
    public Text tempo, record;
    private float minutes;
    private static float seconds = 60;

    

    void Start()
    {
        platformTerra.SetActive(false);
        platformFloresta.SetActive(false);
        capivara1.SetActive(false);
        capivara2.SetActive(false);
        capivara3.SetActive(false);

        comparaPontos = false;
        gameOver.SetActive(false);
        vitoria.SetActive(false);
        fimdejogo.text = "";
        record.text = "";
        // platform.SetActive(false);

        vivo = true;
        ganhou = false;
        platformDefault.SetActive(true);
    }
        


    void Update()
    {
        ControllLevel();
       // Debug.Log(filhas);

        //Debug.Log(playerDoodler.transform.position.y);
    }

    void CapivariasView()
    {
        if(filhas == 1)
        {
            if(capivara1.activeSelf != true)
            {
                capivara1.SetActive(true);
                capivarias.text = "1/3";
            }
            
        }else if(filhas == 2)
        {
            if (capivara2.activeSelf != true)
            {
                capivara2.SetActive(true);
                capivarias.text = "2/3";
            }
        }
        else if (filhas == 3)
        {
            if (capivara3.activeSelf != true)
            {
                capivara3.SetActive(true);
                capivarias.text = "3/3";
            }
        }
    }

    void IdentificaLevel()//1, 2, 3, 4 e final
    {
        
        if (playerDoodler.transform.position.y <= 15)
        {//verifica se level esta construido, level =1
            level = 1;
           // Debug.Log("Level Terra Ativo na posicao "+ playerDoodler.transform.position.y);
        } else if (playerDoodler.transform.position.y <= 25)
        {
            level = 2;
           // Debug.Log("Level Floresta Ativo na posicao " + playerDoodler.transform.position.y);
        }
        ConstroiLevel();
    }

    

    void ConstroiLevel()
    {
        if (level == 1)
        {
          if(platformTerra.activeSelf == true)
            {
               // Debug.Log("Ja tem plataforma n� galera");
            }
            else 
            {
                //Debug.Log("Bota Plataforma caralhooo");
                platformTerra.SetActive(true);
                Vector3 spawnPosition = playerDoodler.transform.position;
                //socorro deus
                for (int i = 0; i < platformCount; i++)
                {
                    spawnPosition.y += Random.Range(.5f, 5f);
                    spawnPosition.x = Random.Range(-2f, 2f);
                    Instantiate(platformTerra, spawnPosition, Quaternion.identity);
                }
                if (capivaraCount > 0)
                {
                    Debug.Log("Adicionando Capivaraaaa");
                    Vector3 spawnCapivara1Position = new Vector3();

                    spawnCapivara1Position.y += Random.Range(1f, 5f);
                    spawnCapivara1Position.x = Random.Range(-2f, 2f);
                    Instantiate(capivaraAlone, spawnCapivara1Position, Quaternion.identity);
                    capivaraCount = capivaraCount - 1;
                    Debug.Log(capivaraCount);
                }

            }
  
        }

       
        else if(level == 2)
        {
            if (platformFloresta.activeSelf == true)
            {
               // Debug.Log("Ja tem plataforma no level 2 galera");
            }
            else
            {
               // Debug.Log("Bota Plataforma nessa bostaaaa");
                platformFloresta.SetActive(true);
                Vector3 spawnPosition = playerDoodler.transform.position;
                //socorro deus
                for (int i = 0; i < platformCount; i++)
                {
                    spawnPosition.y += Random.Range(.5f, 6f);
                    spawnPosition.x = Random.Range(-2f, 2f);
                    Instantiate(platformFloresta, spawnPosition, Quaternion.identity);
                }

                if (capivaraCount > 0)
                {
                    Debug.Log("Adicionando Capivaraaaa");
                    Vector3 spawnCapivara2Position = playerDoodler.transform.position;

                    spawnCapivara2Position.y += Random.Range(.5f, 5f);
                    spawnCapivara2Position.x = Random.Range(-2f, 2f);
                    Instantiate(capivaraAlone, spawnCapivara2Position, Quaternion.identity);
                    capivaraCount = capivaraCount - 1;
                    Debug.Log(capivaraCount);
                }

            }
        }
    }

 

    public void ControllLevel()
    {
        if (vivo)
        {
            if (ganhou)
            {
                vitoria.SetActive(true);
                platformDefault.SetActive(false);
                fimdejogo.text = "CAPIVARIAS NO TOPO!";

                Destroy(playerDoodler.GetComponent<Rigidbody2D>());



                if (comparaPontos)
                {
                    string melhorPontuacao = PlayerPrefs.GetString("melhorTempo");


                    int melhorMinuto, melhorSegundo;
                    int.TryParse(melhorPontuacao.ToUpper(), out melhorMinuto);
                    int.TryParse(melhorPontuacao.Substring(melhorPontuacao.LastIndexOf(@":") + 1), out melhorSegundo);
                    Debug.Log(melhorPontuacao);
                    Debug.Log(melhorMinuto + ":" + melhorSegundo + "PESCADO");
                   if((melhorMinuto + melhorSegundo) == 0)
                    {
                        record.text = "O SEU É O MELHOR TEMPO! " + minutes.ToString() + " : " + seconds.ToString();
                        PlayerPrefs.SetString("melhorTempo", minutes.ToString() + " : " + seconds.ToString());
                        comparaPontos = false;
                    }
                    else
                    {
                        if (minutes <= melhorMinuto)
                        {
                            if (seconds <= melhorSegundo)
                            {

                                record.text = "O SEU É O MELHOR TEMPO! " + minutes.ToString() + " : " + seconds.ToString();
                                PlayerPrefs.SetString("melhorTempo", minutes.ToString() + " : " + seconds.ToString());
                                comparaPontos = false;
                            }
                            else
                            {
                                record.text = "O melhor tempo não é o seu, veja só : " + melhorMinuto + ":" + melhorSegundo;
                                comparaPontos = false;
                            }
                        }
                    }
                    
                }
                

                
               // Debug.Log(PlayerPrefs.GetString("melhorTempo"));
            }
            else
            {
                IdentificaLevel();
                CapivariasView();
                PlayGame();
            }
            
        }
        else
        {
            gameOver.SetActive(true);
            fimdejogo.text = "A UNIDADE FALHOU";
        }
    }
    void PlayGame()
    {
        totalTime += Time.deltaTime;
        minutes = (int)(totalTime / 60);
        seconds = (int)(totalTime % 60);
        tempo.text = minutes.ToString() + " : " + seconds.ToString();

        
    }



}
