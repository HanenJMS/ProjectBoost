using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float fuel;

    public PlayerAttributes()
    {
        fuel = 100f;
    }
    public void UsingFuel()
    {
        fuel = fuel - (1 * Time.deltaTime);
    }

    public Boolean hasFuel()
    {
        if(this.fuel > 0)
        {
            return true;
        }
        return false;
    }
}
