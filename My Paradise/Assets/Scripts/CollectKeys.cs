using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectKeys : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public TMP_Text tmpText;
    private int leftKeys = 3;

    public AudioClip collect;
    public AudioClip correct;
    public AudioClip wrong;

    void Start()
    {
        leftKeys = 3;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "Barrel_04_LOD0")
                {
                    GetComponent<AudioSource>().clip = collect;
                    GetComponent<AudioSource>().Play();
                    if (leftKeys > 0)
                        leftKeys -= 1;
                tmpText.text = leftKeys + " " + "Keys Left";
                    Destroy(key1);
                }
                else if (hit.transform.gameObject.name == "SCharacter_Bird2")
                {
                    GetComponent<AudioSource>().clip = collect;
                    GetComponent<AudioSource>().Play();
                    if (leftKeys > 0)
                        leftKeys -= 1;
                    tmpText.text = leftKeys + " " + "Keys Left";
                    Destroy(key2);
                }
                else if (hit.transform.gameObject.name == "Tent_01_LOD0")
                {
                    GetComponent<AudioSource>().clip = collect;
                    GetComponent<AudioSource>().Play();
                    if (leftKeys > 0)
                        leftKeys -= 1;
                    tmpText.text = leftKeys + " " + "Keys Left";
                    Destroy(key3);
                }
                else if (hit.transform.gameObject.name == "Chest_01_2_LOD0")
                {
                    if (leftKeys == 0)
                    {
                        Destroy(tmpText);
                        GetComponent<AudioSource>().clip = correct;
                        GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        GetComponent<AudioSource>().clip = wrong;
                        GetComponent<AudioSource>().Play();
                    }
                } 
            }
        }
    }
}