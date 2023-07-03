using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairs
{
    public int index;
    public bool isEmpty;
    public Transform transform;
    public Chairs(int index, bool isEmpty, Transform transform)
    {
        this.index = index;
        this.isEmpty = isEmpty;
        this.transform = transform;
    }
}

public class Chair : MonoBehaviour
{
    private Transform[] chairs;
    public List<Chairs> Chairs;
    private List<int> index;

    public List<Chairs> EmptyChairs;

    private void Awake()
    {
        chairs = GetComponentsInChildren<Transform>();
        Chairs = new List<Chairs>();
        index = new List<int>();

        for (int i = 1; i < chairs.Length; i++)
        {
            Chairs chair = new Chairs(i, true, chairs[i]);
            Chairs.Add(chair);
        }
    }
    public List<Transform> SeatChair()
    {
        List<Transform> chairTransforms = new List<Transform>();
        int num;

        foreach(var chair in Chairs)
        {
            if(chair.isEmpty)
            {
                index.Add(chair.index);
            }
        }

        for(int i=0; i<10; i++)
        {
            num = Random.Range(0, Chairs.Count);
            if(index.Contains(num))
            {
                chairTransforms.Add(Chairs[num].transform);
                Chairs[num].isEmpty = false;
                index.Remove(num);
            }
            if (chairTransforms.Count.Equals(3))
                break;
        }
                return chairTransforms;
    }
}
