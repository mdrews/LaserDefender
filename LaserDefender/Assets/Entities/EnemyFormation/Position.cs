using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}
