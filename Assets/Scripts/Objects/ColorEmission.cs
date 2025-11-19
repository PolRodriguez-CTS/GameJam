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

//No funciona no sé porque, he probado a hacer que las dos cosas (tanto el cubo de emision y el emissionTrigger sean triggers pero no va), tampoco va con onTriggerStay
    void OnTriggerStay(Collider other)
    {
        //En la escena, dentro del player hay un sphere collider con la tag de EmissionTrigger, esto activa la condición que a su misma vez cambia la booleana a true
        if(other.gameObject.tag == "EmissionTrigger")
        {
            rangeEmission = true;
        }
    }
}
