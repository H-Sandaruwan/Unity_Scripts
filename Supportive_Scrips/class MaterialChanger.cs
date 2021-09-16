using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public List<Material> allMaterials;
    public List<GameObject> allParts;
    public Material defaultmaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        
        StartCoroutine(Changematerial());
    }

    private void OnDisable()
    {

        StopCoroutine(Changematerial());
        for (int j = 0; j < allParts.Count; j++)
        {
            allParts[j].GetComponent<MeshRenderer>().material = defaultmaterial;
        }

    }


    [SerializeField]
    int currentMateialCount = 0;
    public float wait;
    IEnumerator Changematerial()
    {

        while (true)
        {
            for (int j = 0; j < allParts.Count; j++)
            {

                Debug.Log("Changing Material");
                allParts[j].GetComponent<MeshRenderer>().material = allMaterials[currentMateialCount];

            }
            currentMateialCount++;

            if (currentMateialCount >= allMaterials.Count)
            {
                currentMateialCount = 0;
            }
            yield return new WaitForSeconds(wait);
        }

    }
}
