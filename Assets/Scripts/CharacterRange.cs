using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRange : MonoBehaviour
{
    public List<Character> charInRange = new List<Character>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            charInRange.Add(other.GetComponent<Character>());
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            charInRange.Remove(other.GetComponent<Character>());
        }
    }

    public Transform GetNearestTarget()
    {
        if (charInRange.Count == 0) return null;
        if (charInRange.Count == 1) return charInRange[0].transform;

        float minDistance = (charInRange[0].transform.position - transform.position).magnitude;
        int index = 0; 

        for(int i = 1; i < charInRange.Count; i++)
        {
            float distance = (charInRange[i].transform.position - transform.position).magnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                index = i;
            }    
        }

        return charInRange[index].transform;
    }    
}
