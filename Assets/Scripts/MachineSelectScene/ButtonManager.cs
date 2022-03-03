using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    static Canvas _canvas;
    string[] machine_names = new string[] {"MachineA", "MachineB", "MachineC"};
    GameObject[] machines = new GameObject[3];
    void Start()
    {
        // Canvasコンポーネントを保持
        _canvas = GetComponent<Canvas>();
        // GameObject machineを保持
        for (int i = 0; i < 3; i++) {
            machines[i] = GameObject.Find(machine_names[i]);
        }
    }

    // ボタンの有効・無効を設定する
    public static void SetInteractive(string name, bool b)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                // 指定した名前と一致
                Button btn = child.GetComponent<Button>(); // Buttonコンポーネントを取得する
                btn.interactable = b; // 有効・無効フラグを設定
                return; // おしまい
            }
        }
        // 指定したオブジェクト名が見つからなかった
        Debug.LogWarning("Not found objname:" + name);
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < 3; i++) {
            machines[i].transform.Rotate(new Vector3(0, 0.5f, 0), Space.World);
        }
    }
}
