using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioClip shotClip;
    public AudioClip reloadClip;

    public float damage = 25;
    public int magCapacity = 25;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
}
