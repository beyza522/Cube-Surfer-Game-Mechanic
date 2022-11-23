using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CubeDetector : MonoBehaviour
{
    public int NumberOfDiamonds { get; private set; }
 

    [SerializeField] Text scoreText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            Debug.Log($"Cube {collision.gameObject.name}");

            var cubeBehaviour = collision.gameObject.GetComponent<CubeBehaviour>();

            if (!cubeBehaviour.isStacked)
            {
                PlayerCubeManager.Instance.GetCube(cubeBehaviour);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
            NumberOfDiamonds++;
            Debug.Log("Diamonds: " + NumberOfDiamonds);
            scoreText.text = "Score: " + NumberOfDiamonds * 10;
           
        }

        if (other.gameObject.name == "FinishLine")
        {
            PlayerBehaviour.Instance.VictoryAnimation();
            PlayerBehaviour.Instance.StopPlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Next Level");
        }
    }

    
}
