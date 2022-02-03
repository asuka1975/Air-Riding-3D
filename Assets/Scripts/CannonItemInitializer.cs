using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonItemInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        removeMeshCollider(gameObject);
    }

    private static void removeMeshCollider(GameObject go) {
        GameObject.Destroy(go.GetComponent<MeshCollider>());
        Transform children = go.GetComponentInChildren < Transform > ();
        
        if (children.childCount == 0) {
            return;
        }
        foreach(Transform ob in children) {
            removeMeshCollider(ob.gameObject);
        }   
    }
}
