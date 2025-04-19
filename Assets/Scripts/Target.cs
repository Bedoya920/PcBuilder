using UnityEngine;

public class Target : MonoBehaviour
{
    int lastPlayer = -1;

    void OnCollisionEnter(Collision col)
    {
        int whoHit = col.gameObject.GetComponent<Bullet>().idPlayer;
        
        if(lastPlayer != -1)
        {
            if(lastPlayer != whoHit)
            {
                GameManager.Instance.AddPoint(whoHit);
                GameManager.Instance.RemovePoint(lastPlayer);
                ChangeColor(whoHit);
                lastPlayer = whoHit;
            } 

        } else {
            GameManager.Instance.AddPoint(whoHit);
            ChangeColor(whoHit);
            lastPlayer = whoHit;
        }
        
    }

    private void ChangeColor(int id)
    {
        Renderer targetRenderer = this.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            if (id == 1)
            {
                targetRenderer.material.color = Color.blue; 
            }
            else if (id == 2)
            {
                targetRenderer.material.color = Color.yellow; 
            }
        }
    }
}
