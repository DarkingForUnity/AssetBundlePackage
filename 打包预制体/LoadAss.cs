using System.Collections;
using UnityEngine;

namespace Assets
{
    public class LoadAss : MonoBehaviour
    {

        private string Path = "file:///D:\\unity Project\\Demo\\Assets\\assetbundle\\Together.assetbundle";

        private WWW www;

        // Use this for initialization
        void Start()
        {
            www = new WWW(Path);
            InvokeRepeating("aaa", 0, 0.1f);
        }

        // Update is called once per frame
        void Update()
        {


        }

        private void aaa()
        {
            StartCoroutine(St());
        }

        IEnumerator St()
        {

            if (www.isDone)
            {

                CancelInvoke();
                print(www.text);
                yield return www;
                for (int i = 0; i <= 3807; i++)
                {
                    Object obj = www.assetBundle.LoadAsset("prefab" + i);
                    // GameObject obj = www.assetBundle.LoadAsset("prefab" + i);
                    yield return Instantiate(obj);
               
                }

                yield return www;
            }
            else
            {
                InvokeRepeating("Print", 0, 0.1f);
            }


        }

        private void Print()
        {
            print(www.progress);
        }


   
    }
}
