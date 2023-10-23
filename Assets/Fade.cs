using UnityEngine;

public class Dissapear : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool onTile = false;
    private Material material;
    private Color initialColor;
    private bool isFading = false;

    [SerializeField]
    private float fadeSpeed = 1.0f;

    private void Start()
    {
        initialPosition = transform.position;
        material = GetComponent<Renderer>().material;
        initialColor = material.color;
    }

    private void Update()
    {
        if (onTile && !isFading)
        {
            Color currentColor = material.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, 0.0f, fadeSpeed * Time.deltaTime);
            material.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            if (newAlpha == 0.0f)
            {
                isFading = true;
                Destroy(gameObject, 1.0f); // Destroy the object after 1 second (adjust as needed).
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            onTile = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            onTile = false;
        }
    }
}
