using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour {
    [SerializeField] private GameObject clearUi;
    
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            Instantiate(clearUi);
        }
    }
}
