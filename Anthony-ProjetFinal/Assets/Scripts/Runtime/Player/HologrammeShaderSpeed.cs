using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Player
{
    public class HologrammeShaderSpeed : MonoBehaviour
    {
        private Image _imageRenderer;
        [SerializeField] private float speed;

        // Start is called before the first frame update
        private void Awake()
        {
            _imageRenderer = GetComponent<Image>();
        }

        void Start()
        {
            _imageRenderer.material.SetFloat("_HologrammeSpeed", speed);
        }
    }
}