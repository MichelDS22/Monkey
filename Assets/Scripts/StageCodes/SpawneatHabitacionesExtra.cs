using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneatHabitacionesExtra : MonoBehaviour
{
    public LayerMask HayUnaHabitacion;
    public GeneracionNivel NivelGen;
    private void Update()
    {
        Collider2D DetectorHabitacion = Physics2D.OverlapCircle(transform.position, 1, HayUnaHabitacion);
        if (DetectorHabitacion == null && NivelGen.PararGeneracionNivel == true) {
            //Esto Spawnea una habitacion aleatoria
            int RandomHabitacionExtra = Random.Range(0, NivelGen.HabitacionesExtra.Length);
            Instantiate(NivelGen.HabitacionesExtra[RandomHabitacionExtra], transform.position, Quaternion.identity);
        }
    }
}
