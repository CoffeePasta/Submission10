using UnityEngine;

public class box : MonoBehaviour
{
    public int score = 1;
    [SerializeField] private bool isRespawn;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isRespawn)
                Manager.Instance.AddScore(score);
            else
                Manager.Instance.AddScore(score, this.gameObject);

            gameObject.SetActive(false);
        }
    }
}
