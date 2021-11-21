using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    static Canvas _canvas;
    void Start()
    {
        // Canvas�R���|�[�l���g��ێ�
        _canvas = GetComponent<Canvas>();
    }

    /// �{�^���̗L���E������ݒ肷��
    public static void SetInteractive(string name, bool b)
    {
        foreach (Transform child in _canvas.transform)
        {
            // �q�̗v�f�����ǂ�
            if (child.name == name)
            {
                // �w�肵�����O�ƈ�v
                // Button�R���|�[�l���g���擾����
                Button btn = child.GetComponent<Button>();
                // �L���E�����t���O��ݒ�
                btn.interactable = b;
                // �����܂�
                return;
            }
        }
        // �w�肵���I�u�W�F�N�g����������Ȃ�����
        Debug.LogWarning("Not found objname:" + name);
    }
}
