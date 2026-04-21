using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

[System.Serializable]
public class RequestData
{
    public string pseudoCode;
}

[System.Serializable]
public class ResponseData
{
    public string result;
}

public class TranslateClient : MonoBehaviour
{
    private static TranslateClient instance;
    private static string apiUrl = "https://6mfasrmurjfywsb5uayaszm2my0xfjvt.lambda-url.us-east-2.on.aws/";

    private static void Init()
    {
        if (instance == null)
        {
            GameObject obj = new GameObject("TranslateClient");
            instance = obj.AddComponent<TranslateClient>();
            DontDestroyOnLoad(obj);
        }
    }

    public static void SendPseudoCode(string code, System.Action<string> onSuccess, System.Action<string> onError)
    {
        Init();
        instance.StartCoroutine(instance.PostRequest(code, onSuccess, onError));
    }

    private IEnumerator PostRequest(string code, System.Action<string> onSuccess, System.Action<string> onError)
    {
        RequestData data = new RequestData { pseudoCode = code };
        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            Debug.Log(responseText);
            ResponseData response = JsonUtility.FromJson<ResponseData>(responseText);
            if (response.result.Contains("Erro"))
            {
                onError?.Invoke(response.result);
            }
            else
            {
                onSuccess?.Invoke(response.result);
            }
            
        }
        else
        {
            ResponseData response = JsonUtility.FromJson<ResponseData>(request.error);

            onError?.Invoke(request.error);
        }
    }
}