using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            winPanel.SetActive(true);
            Destroy(gameObject);
        }

        else
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
