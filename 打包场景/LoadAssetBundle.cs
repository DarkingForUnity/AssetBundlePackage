using System.Collections;
using UnityEngine;

namespace Assets
{
    /// <inheritdoc />
    /// <summary>
    /// 脚本位置：需要加载物体的场景中任意物体上
    /// 脚本功能：加载物体
    /// </summary>
    public class LoadAssetBundle : MonoBehaviour
    {

        private string url;
        private string assetname;

        void Start()
        {
            // 下载压缩包，写出具体的名字
            // url = "file://" + Application.dataPath + "/Scene.unity3d";
            url = "http://127.0.0.1/WangSh/Scene.unity3d";
          //   url = "file:///C:\\Users\\pc\\Desktop\\Scene.unity3d";
            // unity预制体名字，即被打包的场景名字叫 2
            assetname = "01";

            StartCoroutine(Download());
        }

        IEnumerator Download()
        {

            WWW www = new WWW(url);
            yield return www;
            print(www.error);
            if (www.error != null)
            {
                Debug.Log("下载失败");
            }
            else
            {
                AssetBundle bundle = www.assetBundle;
                Application.LoadLevel("01");
                print("跳转场景");
                // AssetBundle.Unload(false)，释放AssetBundle文件内存镜像，不销毁Load创建的Assets对象
                // AssetBundle.Unload(true)，释放AssetBundle文件内存镜像同时销毁所有已经Load的Assets内存镜像
                bundle.Unload(false);
            }

            // 中断正在加载过程中的WWW
            www.Dispose();
        }

    }
}