﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public int cofre;

    public void Pagar(int recompensa) {
        cofre += recompensa;
        print("recompensa paga: " + recompensa.ToString());
    }


}