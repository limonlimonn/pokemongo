using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour
{
    const string Key = "cydP18CWm7BCYetAANI4DOPcbl8ssckL";

    public Renderer maprender;
    Vector2 PlayerPosition =
       new Vector2(50.437990f, 30.521626f);  //Latitude, Longitude
                                             //   new Vector2(42.3627f, -71.05686f);  //Latitude, Longitude

    int _zoom = 17;
    string _maptype = "map";
    string _url;

    void Start()
    {
        StartLoadMap(PlayerPosition);
    }


    private void StartLoadMap(Vector2 playerPosition)
    {
        _url = "http://open.mapquestapi.com/staticmap/v4/getmap?key=" + Key 
            + "&size=1280,1280&zoom=" + _zoom 
            + "&type=" + _maptype 
            + "&center=" + PlayerPosition.x + "," + PlayerPosition.y;
       // Debug.Log(_url);

        StartCoroutine(LoadImage());
    }

    private IEnumerator LoadImage()
    {
        WWW www = new WWW(_url);
        while (!www.isDone)
        {
            Debug.Log("progress = " + www.progress);
            yield return null;
        }

        if (www.error == null)
        {
            Debug.Log("Updating map 100 %");
            Debug.Log("Map Ready!");
            yield return new WaitForSeconds(0.5f);
            maprender.material.mainTexture = null;
            Texture2D tmp;
            tmp = new Texture2D(1280, 1280, TextureFormat.RGB24, false);
            maprender.material.mainTexture = tmp;
            www.LoadImageIntoTexture(tmp);
        }
        else {
            Debug.Log("Map Error:" + www.error);
            yield return new WaitForSeconds(1);
            maprender.material.mainTexture = null;
        }

        maprender.enabled = true;
    }
}
