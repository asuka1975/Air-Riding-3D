using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    static Canvas _canvas;
    void Start()
    {
        // Canvasコンポーネントを保持
        _canvas = GetComponent<Canvas>();
    }

    /// ボタンの有効・無効を設定する
    public static void SetInteractive(string name, bool b)
    {
        foreach (Transform child in _canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == name)
            {
                // 指定した名前と一致
                // Buttonコンポーネントを取得する
                Button btn = child.GetComponent<Button>();
                // 有効・無効フラグを設定
                btn.interactable = b;
                // おしまい
                return;
            }
        }
        // 指定したオブジェクト名が見つからなかった
        Debug.LogWarning("Not found objname:" + name);
    }
}
