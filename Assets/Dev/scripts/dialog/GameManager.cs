using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DialogConf[] dialogConfs;

    [MenuItem("Tools/检测对话数据配置")]
    public static void CheckDialogConfs()
    {
        DialogConf[] dialogConfs = Resources.LoadAll<DialogConf>("Conf");
        // loop thorugh all dialog conf files
        for ( int i = 0; i < dialogConfs.Length; i ++)
        {
            for (int j = 0; j < dialogConfs[i].DialogModels.Count; j++)
            {
                if (dialogConfs[i].DialogModels[j].NPCConf == null ||
                    dialogConfs[i].DialogModels[j].NPCConf.Head == null )
                {
                    Debug.LogError("导入对话数据存在问题");
                }
            }
        }
    }
    private void Awake()
    {
        Instance = this;
        DialogConf[] dialogCOnfs = Resources.LoadAll<DialogConf>("Conf");
    }

    public DialogConf GetDialogConf(int index)
    {
        return dialogConfs[index];

    }


    /// <summary>
    /// 摄像机效果-闪烁
    /// </summary>
    public void ScreenEF(float delay)
    {
        StartCoroutine(DoScreenEF(delay));

    }

    private IEnumerator DoScreenEF(float delay)
    {
        GameObject.Find("Canvas/BG").GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(delay);
        GameObject.Find("Canvas/BG").GetComponent<Image>().color = Color.white;
    }

}
