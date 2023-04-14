using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountDownUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI countdownText;
    void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    }


    private void Update() {
        countdownText.text = Mathf.Ceil(KitchenGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsCountDownToStartActive()) {
            Show();
        } else {
            Hide();
        }
    }


    private void Show() {
        gameObject.SetActive(true);
    }
    private void Hide() {
        gameObject.SetActive(false);
    }
}
