using System;
using UnityEngine;
using TMPro; //refering to texes
using UnityEngine.UI; //for ui
public class rr : MonoBehaviour
{
    private static rr instance; //we make singlton
    
    
    public TextMeshProUGUI score;
    private int scorei;
    public TextMeshProUGUI highscore;
    private int highscorei;
    public TextMeshProUGUI wave;
    private int wavei;
    
    private gettinghurt sta;
    
    
    private Color32 activeColor  = new Color(1, 1, 1, 1);
    private Color32 inactiveColor = new Color(1, 1, 1,0.05f) ; //the forth one is opacity

    public Image[] life; //for lives
    public Image[] health; //for heakth

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }
    
    
    //updating feilds method

    public static void updatinghlive(int l)
    {

        foreach (Image i in instance.life)
        {
            i.color = instance.inactiveColor;
        }

        for (int i = 0; i < l; i++)
        {
            instance.life[i].color = instance.activeColor;
        }
    }

    public static void updatehealth(int h)
    {
        foreach (Image i in instance.health)
        {
            i.color = instance.inactiveColor;
        }
        
        for (int i = 0; i < h; i++)
        {
            instance.health[i].color = instance.activeColor;
        }
    }

    public static void updatinghighscore(int s)
    {
        if (instance.highscorei < s)
        {
            instance.highscorei = s; //cahnge the value
            instance.highscore.text = instance.highscorei.ToString("000,000"); //chnage the text
        }
    }

    public static void updatescore(int s)
    {
        instance.scorei += s;
        instance.score.text = instance.scorei.ToString("000,000");
    }

    public static void updatewave()
    {
        instance.wavei++;
        instance.wave.text = instance.wavei.ToString();
    }

    public static void updateactivehealt(int h)
    {
        for (int i = 0; i < h; i++)
        {
            instance.health[i].color = instance.activeColor;
        }
    }
    
    public static void updateactivelife(int h)
    {
        for (int i = 0; i < h; i++)
        {
            instance.life[i].color = instance.activeColor;
        }
    }

    public static int gethighscore()
    {
        return instance.highscorei;
    }

    public static void Resetui()
    {
        instance.scorei = 0;
        instance.wavei = 0;
        instance.score.text = instance.scorei.ToString("000,000");
        instance.wave.text = instance.wavei.ToString("000,000");
        updateactivehealt(3);
        updateactivelife(3);
    }
}
