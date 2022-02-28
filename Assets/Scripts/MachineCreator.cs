using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MachineCreator : MonoBehaviour
{
    private Vector3[] StartPositions = {
        new Vector3(100, 10, 100),
        new Vector3(100, 10, 200),
        new Vector3(200, 10, 200),
        new Vector3(200, 10, 200),
        new Vector3(150, 10, 50),
        new Vector3(250, 10, 150),
        new Vector3(50, 10, 150),
        new Vector3(150, 10, 250),
    };

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(WaitCameraInitialized));
    }

    IEnumerator WaitCameraInitialized()
    {
        var r = new System.Random();
        var positionId = r.Next(0, 7);
        while (Camera.main.GetComponent<CameraController_machine>() == null)
        {
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.2f);
        
        //生成するマシンのIDを取得
        var id = GameObject.FindWithTag("SharedParams").GetComponent<SharedParams>().Get<MachineSelectData>().id;
        string machine_name = "Machine" + id;
        PhotonNetwork.Instantiate(machine_name , StartPositions[positionId], Quaternion.identity);
    }
}
