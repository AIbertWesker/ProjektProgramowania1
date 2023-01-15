using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kostka : MonoBehaviour
{

    private Sprite[] stronaKostki;
    private SpriteRenderer render;
    private int kogoKolej = 1;
    private bool zezwolRzut = true;


    // Start is called before the first frame update
    private void Start()
    {
        zezwolRzut = true;
        render = GetComponent<SpriteRenderer>();
        stronaKostki = Resources.LoadAll<Sprite>("kostka/");
        render.sprite = stronaKostki[5];  //jak chce inny sprajt na start to zmienic tu
    }
    private void OnMouseDown()
    {
        if(!Kontrolki.gameOver && zezwolRzut){
            StartCoroutine("RzutKostki");
        }
    }

    private IEnumerator RzutKostki()
    {
        zezwolRzut = false;
        int losowanie = 0;
        for (int i = 0; i <= 20; i++)
        {
            losowanie = Random.Range(0, 6);
            render.sprite = stronaKostki[losowanie];
            yield return new WaitForSeconds(0.05f);
        }

        Kontrolki.wyrzuconaKostka = losowanie + 1;
        if (kogoKolej == 1)
        {
            Kontrolki.RuchGraczy(1);
        } else if (kogoKolej == -1)
        {
            Kontrolki.RuchGraczy(2);
        }
        kogoKolej *= -1;
        zezwolRzut = true;
    }
}