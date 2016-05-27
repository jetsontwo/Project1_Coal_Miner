using UnityEngine;
using System.Collections;

public class Store_Script : MonoBehaviour {

    public int money;
    
    public void Buy_Food(Character_Status g)
    {
        if (money >= 10 && g.hunger >= 25)
        {
            g.hunger -= 25;
            money -= 10;
        }
        else if (money >= 10)
        {
            g.hunger = 0;
            money -= 10;
        }
    }

    public void Buy_Heat(Character_Status wife, Character_Status kid)
    {
        if (money >= 15 && wife.cold >= 25 && kid.cold >= 25)
        {
            wife.cold -= 25;
            kid.cold -= 25;
        }
        else if (money >= 15 && wife.cold >= 25)
        {
            kid.cold = 0;
            wife.cold -= 25;
        }
        else if(money >= 15 && kid.cold >= 25)
        {
            kid.cold -= 25;
            wife.cold = 0;
        }
        else if (money >= 15)
        {
            kid.cold = 0;
            wife.cold = 0;
        }
    }

    public void Buy_Medicine(Character_Status g)
    {
        if (money >= 30 && g.sickness >= 25)
        {
            g.sickness -= 25;
        }
        else if (money >= 30)
        {
            g.sickness = 0;
        }
    }
}
