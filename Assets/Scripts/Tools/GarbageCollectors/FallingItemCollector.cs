using Assets.Scripts.Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Tools.GarbageCollectors
{
    public class FallingItemCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == Tag.Player)
            {
                SceneManager.LoadScene(0);
            }

            Destroy(other.gameObject);
        }
    }
}
