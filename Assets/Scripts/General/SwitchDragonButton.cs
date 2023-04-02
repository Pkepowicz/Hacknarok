using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDragonButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChooseFire()
    {
        GameManager.Instance.ActivateDragon(0);
    }
    public void ChooseLigt()
    {
        GameManager.Instance.ActivateDragon(1);
    }
    public void ChooseEarth()
    {
        GameManager.Instance.ActivateDragon(2);
    }
}
