using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Duración de partida (s)")]
    [SerializeField] private float gameDuration = 60f;
    private float remainingTime;

    [Header("UI Text")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text time1Text;
    [SerializeField] private TMP_Text time2Text;
    [SerializeField] private TMP_Text resultText;

    private List<Target> targets;
    private float ownedTime1 = 0f;
    private float ownedTime2 = 0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }
    }

    private void Start()
    {
        remainingTime = gameDuration;
        Target[] found = Object.FindObjectsByType<Target>(FindObjectsSortMode.None);
        targets = new List<Target>(found);
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        // Cuenta atrás
        if (remainingTime > 0f)
        {
            remainingTime -= dt;
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();
        }

        // Acumula tiempo de posesión según la propiedad CurrentOwner
        foreach (var t in targets)
        {
            if (t.CurrentOwner == 1) ownedTime1 += dt;
            else if (t.CurrentOwner == 2) ownedTime2 += dt;
        }
        time1Text.text = Mathf.CeilToInt(ownedTime1).ToString();
        time2Text.text = Mathf.CeilToInt(ownedTime2).ToString();

        // Al acabarse el tiempo, declara ganador
        if (remainingTime <= 0f)
            EndGame();
    }

    private void EndGame()
    {
        if (ownedTime1 > ownedTime2) resultText.text = "¡Jugador 1 Gana!";
        else if (ownedTime2 > ownedTime1) resultText.text = "¡Jugador 2 Gana!";
        else resultText.text = "Empate";
    }
}
