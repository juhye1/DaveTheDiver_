using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CustomerSpawnFromBundle : MonoBehaviour
{

    private string bundleName;
    private string assetName;
    private Customer customer;

    private void Awake()
    {
        bundleName = "customer";
        assetName = "Customer";
    }
    public Customer SpawnCustomer()
    {
        return customer;
    }

    public IEnumerator LoadFromLocalAsyncProcess(Vector3 spawnPoint)
    {
        AssetBundleCreateRequest asyncBundleRequest =
            AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));

        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("번들 로드 실패");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        var prefab = assetRequest.asset as GameObject;

        Instantiate(prefab, spawnPoint, Quaternion.identity);
        customer = prefab.GetComponent<Customer>();

        yield return new WaitForSeconds(0.01f);
        localAssetBundle.Unload(true);
    }
}
