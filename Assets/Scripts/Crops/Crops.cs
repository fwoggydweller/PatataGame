using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Crop")]
public class Crops : ScriptableObject
{
    public int timeToGrow = 10;
    public Item yield;
    public int count = 1;
}
