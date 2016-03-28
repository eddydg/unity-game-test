using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {

    public Transform player;

	void OnTriggerEnter(Collider other)
    {
        print("enter");
        other.transform.parent = this.transform;
    }

    void OnTriggerExit(Collider other)
    {
        print("exit");
        other.transform.parent = null;
    }

}
