using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirSalas : MonoBehaviour
{
    public int TipoDeSala;

    public void DestruirSala()
    {
            Destroy(gameObject);
    }
}
