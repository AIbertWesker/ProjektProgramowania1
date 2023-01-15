using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz1 : GraczyStaty
{

    public static int wszystkieruchy1;
    public int wszystkieruchy2;

    public void Start()
    {
        wszystkieruchy1 = iloscruchow;
    }
    public void Update()
    {
        wszystkieruchy2 = wszystkieruchy1;
    }

}
