using UnityEngine;

public class Grab : MonoBehaviour
{
    //Pegar este script en el player o dejar separado??

    //Grab
    //Tamaño del sensor
    [SerializeField] private Vector3 _grabSensorSize;
    [SerializeField] private Transform _grabSensor;

    //Posición a la que se va a llevar al objeto grabeado
    [SerializeField] private Transform _hands;
    //Transfomr del objeto grabeado
    private Transform _grabbedObject;

    private void GrabObject()
    {
        if(_grabbedObject == null)
        {
            Collider[] objectsToGrab = Physics.OverlapBox(_grabSensor.position, _grabSensorSize);

            foreach(Collider item in objectsToGrab)
            {
                IGrabeable grabeable = item.GetComponent<IGrabeable>();

                if(grabeable != null)
                {
                    _grabbedObject = item.transform;
                    _grabbedObject.SetParent(_hands);
                    _grabbedObject.position = _hands.position;
                    _grabbedObject.rotation = _hands.rotation;
                    _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

        else
        {
            _grabbedObject.SetParent(null);
            _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            _grabbedObject = null;
        }
    }
}

/*
    Grab
        {necesitamos las siguientes variables, un vector3 _handSensorSize, para definir el tamaño de la colision para poder agarrar un objeto, un transform donde movamos el objeto para simular que está en las manos del personaje y un transform para almacenar el transform del objeto grabeado.

        - Acceder al collider de los objetos mediante un array que almacene dichos objetos en un radio determinado (OverlapBoxAll)

        - comprobar si ya estamos grabeando algún objeto, si no es el caso (grabed object == null):

        - Interfaz de objeto grabeable para poder acceder y comprobar si el objeto que intentamos agarrar tiene la interfaz

        - si tiene la interfaz, y por lo tanto, es grabeable, lo movemos a la "mano del jugador" (el transform de un empty), y hacemos que sea child de este transform

        - tenemos que hacer que su rigidbody (en caso de tenerlo), sea cinemático al ser agarrado)

        -------------------------------------

        - Si grabed object != null (es decir, ya tenemos un objeto agarrado):

        - Quitamos el parent del objeto, devolvemos su rigidbody a dinamico y quitamos el transform del objeto almacenado en la variable de transform. (_grabedObject = null)
    */
