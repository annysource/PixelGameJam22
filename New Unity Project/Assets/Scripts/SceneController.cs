using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject painelLoja, painelCreditos, painelMain;

    void Start()
    {
        painelLoja.SetActive(false);
        painelCreditos.SetActive(false);
        painelMain.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("CoreLoop");
    }

    public void EntrarLoja()
    {
        painelMain.SetActive(false);
        painelLoja.SetActive(true);
    }
    public void EntrarCreditos()
    {
        painelMain.SetActive(false);
        painelCreditos.SetActive(true);
    }
    public void Voltar()
    {
        painelMain.SetActive(true);
        painelLoja.SetActive(false);
        painelCreditos.SetActive(false);
    }
}
