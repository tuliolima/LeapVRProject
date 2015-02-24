using UnityEngine;
using System.Collections;
using Leap;

public class Coordenadas : MonoBehaviour {

	public Transform objeto;
	public float distancia;
	protected Vector3 posicaoAnterior = Vector3.zero;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1")) {
			Marcar();
		}
	}

	// Create a marker from de position of the hand
	void Marcar () {

		HandController controller = GetComponent<HandController> ();
		HandModel[] hands = controller.GetAllGraphicsHands ();

		if (hands.Length != 0 && DistanciaEntreVetores(posicaoAnterior, hands[0].GetPalmPosition()) > distancia) {
			posicaoAnterior = hands[0].GetPalmPosition();
			Transform forma = Instantiate (objeto, posicaoAnterior, Quaternion.identity) as Transform;
			forma.rotation = hands[0].GetPalmRotation();
		}
	}

	//Returns the distance between two Vectors
	public float DistanciaEntreVetores (Vector3 inicio, Vector3 fim) {

		return (fim - inicio).magnitude;
	}
}
