using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public Text contPontos;
    private float cont;

    // Update is called once per frame
    void Update()
    {
        cont = GetComponent<SpawnPlatformsV2>().offset-2;
        contPontos.text = cont.ToString();
    }
}
