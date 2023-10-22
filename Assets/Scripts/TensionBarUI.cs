using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TensionBarUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float tension;
    public float maxTension = 100f;
    public Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        
        slider.maxValue = (float)maxTension;
        slider.value = (float)tension;
    }

    public void setTension(float newtension){
        tension = newtension;
        slider.value = tension;
    }

}
