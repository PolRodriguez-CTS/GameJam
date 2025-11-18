using UnityEngine;


public class ColorEmission : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material materials;


    public bool rangeEmission = false;
    public float numberEmission = 0f;
    public float speed = 1f;


    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materials = meshRenderer.material;


        materials.EnableKeyword("_EMISSION");
    }


    void Update()
    {
        if (rangeEmission)
        {
            numberEmission += Time.deltaTime * speed;
        }
        else
        {
            numberEmission -= Time.deltaTime * speed;
        }


        numberEmission = Mathf.Clamp(numberEmission, 0f, 2f);


        materials.SetColor("_EmissionColor", Color.white * numberEmission);
    }
}
