using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public static int maxHp;
    public static int currentHp;
    public int hp;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 20;
        currentHp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        hp = currentHp;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }
        hpText.text = "HP: " + hp.ToString();


    }
}
