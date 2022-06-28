using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

[ExecuteInEditMode]
public class GetNftMetadata : MonoBehaviour
{
    public string Apikey = Data.Apikey;
    [SerializeField] Enumeration.ImageSize imageSize;
    [SerializeField] Enumeration.ChainId chainId;
    public string contractAddress = "";
    public int tokenId;
    public NftExternalMetadata.Nft_Data NftMadata;

    private void Update()
    {
        Data.Apikey = Apikey;
    }

    public void PreviewNft()
    {
        var uri = ParseUrl.NFTExternalMetadata(chainId, contractAddress, tokenId);
        if (uri.Item1)
        {
            StartCoroutine(GetRequest(uri.Item2));
        }

    }
    // Update is called once per frame
    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            switch (request.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Error: {request.error}");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"Error: {request.error}");
                    break;
                case UnityWebRequest.Result.Success:
                    var text = request.downloadHandler.text;
                    var result = JsonUtility.FromJson<NftExternalMetadata.Rootobject>(text);
                    var metadata = result.data.items[0].nft_data[0];
                    NftMadata = metadata;
                    var getImage = new DownloadImage();
                    switch (imageSize)
                    {
                        case Enumeration.ImageSize._256:
                            StartCoroutine(getImage.FromUrl(metadata.external_data.image_256, gameObject));
                            break;
                        case Enumeration.ImageSize._512:
                            StartCoroutine(getImage.FromUrl(metadata.external_data.image_512, gameObject));
                            break;
                        case Enumeration.ImageSize._1024:
                            StartCoroutine(getImage.FromUrl(metadata.external_data.image_1024, gameObject));
                            break;
                        default:
                            StartCoroutine(getImage.FromUrl(metadata.external_data.image, gameObject));
                            break;
                    }
                    break;
            }

        }
    }
}
