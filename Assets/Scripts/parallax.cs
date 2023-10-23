using UnityEngine;

public class parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animationSpeed = 1f;
   void Awake()
   {
        meshRenderer = GetComponent<MeshRenderer>();
   }
   void Update()
   {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime , 0);
   }
}
