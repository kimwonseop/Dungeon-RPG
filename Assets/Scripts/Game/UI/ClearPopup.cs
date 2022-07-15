using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;
using UnityEngine.UI;

public class ClearPopup : MonoBehaviour {
    [SerializeField] private Button button_clear;

    private void Start() {
        button_clear.onClick.AddListener(()=> {
            GameManager.Instance.ResetGame();
            Destroy(gameObject);
        });
    }
}
