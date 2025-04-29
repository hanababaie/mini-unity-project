using UnityEngine;

[System.Serializable] //we can see it in editoer
public class gettinghurt //it doent have to be : MonoBehaviour cause we have no method just for status of ship
{
    [Range(1,5)]
    public int maxhealth = 3;
    [HideInInspector] //we want to chage
    public int currenthealth;
    [HideInInspector]
    public int maxlives = 3;
        [HideInInspector]
    public int currenlives = 3;

    public float shipspeed = 20; // for upgrade
    public float firepower = 0.5f;

    public void updatelife()
    {
        currenlives = maxlives;
    }

    public void updatehealth()
    {
        currenthealth = maxhealth;
    }
    
}
