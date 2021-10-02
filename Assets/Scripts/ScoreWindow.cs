/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour {

    private static ScoreWindow instance;

    private TextMeshPro GemsText;
    private TextMeshPro CoinsText;

    private void Awake() {
        instance = this;
        GemsText = transform.Find("GemsText").GetComponent<TextMeshPro>();
        CoinsText = transform.Find("CoinsText").GetComponent<TextMeshPro>();
    }
    
    private void Update() {
        GemsText.text = Score.GetScoreGem().ToString();
        CoinsText.text = Score.GetScoreCoin().ToString();
    }


    public static void HideStatic() {
        instance.gameObject.SetActive(false);
    }
}
