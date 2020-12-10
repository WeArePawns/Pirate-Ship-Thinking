using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using uAdventure.Runner;

public class GameManager : MonoBehaviour
{
    public Text coinsText;
    public Text timeText;
    void Start()
    {
        StartCoroutine(IncreaseTime());
    }

    void Update()
    {
        coinsText.text = Game.Instance.GameState.GetVariable("Monedas").ToString();

        if (Game.Instance.GameState.CheckFlag("Win") == 0)
            StopAllCoroutines();
    }

    IEnumerator IncreaseTime()
    {
        int time = Game.Instance.GameState.GetVariable("Time");
        time++;
        Game.Instance.GameState.SetVariable("Time", time);
        timeText.text = ((int)(time / 60.0f)).ToString() + "m" + ((int)(time % 60.0f)).ToString() + "s";
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(IncreaseTime());
    }
}
