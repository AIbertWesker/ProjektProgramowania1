using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrolki : MonoBehaviour
{

    private static GameObject player1Text, player2Text, zwyciezcaText;
    private static GameObject player1, player2;
    public static int wyrzuconaKostka = 0;  //to pojdzie na skrypt kostki
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
    player1StartWaypoint = 0;
    player2StartWaypoint = 0;
    gameOver = false;
    player1 = GameObject.Find("Auditor");
    player2 = GameObject.Find("Tricky");
    player1Text = GameObject.Find("Player1Text");
    player2Text = GameObject.Find("Player2Text");
    zwyciezcaText = GameObject.Find("zwyciezcaText");

    player1.GetComponent<RuchDoWaypoint>().moveAllow = false;
    player2.GetComponent<RuchDoWaypoint>().moveAllow = false;

    zwyciezcaText.gameObject.SetActive(false);
    player1Text.gameObject.SetActive(true);
    player2Text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   //warunki do ruchu (waypoint startowy bedzie na runde sie zmienial na ostatni)
        if (player1.GetComponent<RuchDoWaypoint>().waypointIndex > player1StartWaypoint + wyrzuconaKostka)
        {
            player1.GetComponent<RuchDoWaypoint>().moveAllow = false;
            player1Text.gameObject.SetActive(false);
            player2Text.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<RuchDoWaypoint>().waypointIndex - 1;
        }
        //to samo ale playerzu na odwórt
        if (player2.GetComponent<RuchDoWaypoint>().waypointIndex > player2StartWaypoint + wyrzuconaKostka)
        {
            player2.GetComponent<RuchDoWaypoint>().moveAllow = false;
            player2Text.gameObject.SetActive(false);
            player1Text.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<RuchDoWaypoint>().waypointIndex - 1;
        }


        if(player1.GetComponent<RuchDoWaypoint>().waypointIndex == player1.GetComponent<RuchDoWaypoint>().waypointy.Length){
            zwyciezcaText.gameObject.SetActive(true);
            player1Text.gameObject.SetActive(false);
            player2Text.gameObject.SetActive(false);
            zwyciezcaText.GetComponent<Text>().text = "Gracz nr1 wygrał w " + Gracz1.wszystkieruchy1 + " ruchach.";
            gameOver = true;
        }
        if(player2.GetComponent<RuchDoWaypoint>().waypointIndex == player2.GetComponent<RuchDoWaypoint>().waypointy.Length){
            zwyciezcaText.gameObject.SetActive(true);
            player1Text.gameObject.SetActive(false);
            player2Text.gameObject.SetActive(false);
            zwyciezcaText.GetComponent<Text>().text = "Gracz nr2 wygrał w "+ Gracz2.wszystkieruchy1 + " ruchach.";
            gameOver = true;
        }
    }

         public static void RuchGraczy(int ktoregoKolej)
         {
            switch (ktoregoKolej) {
                case 1:
                player1.GetComponent<RuchDoWaypoint>().moveAllow = true;
                Gracz1.wszystkieruchy1 += 1;
                break;

                case 2:
                player2.GetComponent<RuchDoWaypoint>().moveAllow = true;
                Gracz2.wszystkieruchy1 += 1;
                break;
            }
         }
}
