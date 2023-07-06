using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjetosSpawn : MonoBehaviour {

    public GameObject[] Objetos;

    private void Start()
    {
        int random = Random.Range(0, Objetos.Length);
        GameObject instance = (GameObject)Instantiate(Objetos[random], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}
