using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    public void AddPoint(int id)
    {
        if(id == 1)
        {
            scorePlayer1++;
            print(scorePlayer1);
        } else{
            scorePlayer2++;
            print(scorePlayer2);
        }
        
    }

    public void RemovePoint(int id)
    {
        if(id == 1)
        {
            scorePlayer1--;
        } else{
            scorePlayer2--;
        }
    }


}
