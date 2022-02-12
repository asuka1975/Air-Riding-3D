using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonItemEquippedInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        removeMeshCollider(gameObject);
    }

    private static void removeMeshCollider(GameObject go) {
        // MeshColliderの削除
        GameObject.Destroy(go.GetComponent<MeshCollider>());
        // 子プレハブがなければ終了、あれば再帰
        Transform children = go.GetComponentInChildren<Transform>();
        if (children.childCount == 0) return;
        foreach (Transform ob in children) removeMeshCollider(ob.gameObject);
    }
}
