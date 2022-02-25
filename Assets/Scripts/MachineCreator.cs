using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MachineCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(WaitCameraInitialized));
    }

    IEnumerator WaitCameraInitialized()
    {
        while (Camera.main.GetComponent<CameraController_machine>() == null)
        {
            yield return new WaitForSeconds(0.1f);
        }
        
        //生成するマシンのIDを取得
        var id = GameObject.FindWithTag("SharedParams").GetComponent<SharedParams>().Get<MachineSelectData>().id;
        string machine_name = "Machine" + id;
        PhotonNetwork.Instantiate(machine_name , new Vector3(100, 10, 100), Quaternion.identity);
    }
}
