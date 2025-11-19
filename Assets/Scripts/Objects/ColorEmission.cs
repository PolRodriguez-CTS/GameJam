using UnityEngine;


public class ColorEmission : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material materials;


    public bool rangeEmission = false;
    public float numberEmission = 0f;
    public bool isColored = false;
    public float speed;


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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3 && !isColored)
        {
            speed = 1.5f;
            rangeEmission = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 3 || !isColored)
        {
            speed = 2.5f;
            rangeEmission = false;
        }
    }
}
