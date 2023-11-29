using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyButton2 : MonoBehaviour
{
    
    public CircleDrawer circleDrawer;
    public LineDrawer lineDrawer;
    private bool check = false;
    
    public void OnButtonClick()
    {
        check = !check;
        if(check)
            {
            circleDrawer.check(true);
            lineDrawer.check(false);
            }
        else{
             circleDrawer.check(false);
            lineDrawer.check(true);
        }
    }
    
    
}
