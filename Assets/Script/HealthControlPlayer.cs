using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControlPlayer : MonoBehaviour {
     public Image bar;
     public float fill;

     public void Start()
     {
          fill = 1f;
     }

     public void Update()
     {
          bar.fillAmount = fill;
     }
}
