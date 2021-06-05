using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperBar : MonoBehaviour
{
    public Slider slider; 

    public void SetMaxSuper( int super)
    {
        slider.maxValue = super;
        slider.value = super; 
    }
  
    public void SetSuper(int super)
    {
        slider.value = super; 
    }
}
