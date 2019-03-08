using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAssetBundle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>  
    /// 将选中的预制分别打包  
    /// </summary>  
    [MenuItem("AssetBundleDemo/Create AssetBundles By themselves")]
    static void CreateAssetBundleThemelves()
    {
        //获取要打包的对象（在Project视图中）  
        Object[] selects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        //遍历选中的对象  
        foreach (Object obj in selects)
        {
            //这里建立一个本地测试  
            //注意本地测试中可以是任意的文件，但是到了移动平台只能读取路径StreamingAssets里面的  
            //StreamingAssets是只读路径，不能写入  
            string targetPath = Application.dataPath + "/AssetBundleLearn/StreamingAssets/" + obj.name + ".assetbundle";//文件的后缀名是assetbundle和unity都可以  
            if (BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies))
            {

                Debug.Log(obj.name + "is packed successfully!");
            }
            else
            {
                Debug.Log(obj.name + "is packed failly!");
            }
        }
        //刷新编辑器（不写的话要手动刷新,否则打包的资源不能及时在Project视图内显示）  
        AssetDatabase.Refresh();
    }




    /// <summary>  
    /// 将选中的预制打包到一起  
    /// </summary>  
    [MenuItem("AssetBundleDemo/Create AssetBundles Together")]
    static void CreateAssetBundleTogether()
    {
        //要打包的对象  
        Object[] selects = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        //要打包到的路径  
        //string targetPath = Application.dataPath + "/AssetBundleLearn/StreamingAssets/Together.assetbundle";
        string targetPath = Application.dataPath + "/assetbundle/Together.assetbundle";
        if (BuildPipeline.BuildAssetBundle(null, selects, targetPath, BuildAssetBundleOptions.CollectDependencies))
        {
            Debug.Log("Packed successfully!");

        }
        else
        {
            Debug.Log("Packed failly!");
        }
        //刷新编辑器（不写的话要手动刷新）  
        AssetDatabase.Refresh();
    }


    [MenuItem("Tools/BatchPrefab All Children")]
    
    public static void BatchPrefab()
    {
        
        Transform tParent = ((GameObject)Selection.activeObject).transform;
       


        
        Object tempPrefab;
        
        int i = 0;
        
        foreach (Transform t in tParent)
        {
           
            tempPrefab = EditorUtility.CreateEmptyPrefab("Assets/Prefab/prefab" + i + ".prefab");
            print(i);
            tempPrefab = EditorUtility.ReplacePrefab(t.gameObject, tempPrefab);
           
            i++;
            
        }
       
    }
}
