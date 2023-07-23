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
    [SerializeField] private Transform[] chairs;
    public List<Chairs> Chairs;
    private List<int> index;

    private void Awake()
    {
        Chairs = new List<Chairs>();
        index = new List<int>();

        for (int i = 0; i < chairs.Length; i++)
        {
            Chairs chair = new Chairs(i, true, chairs[i]);
            Chairs.Add(chair);
        }
    }
    public List<Chairs> EmptyChairs()
    {
        List<Chairs> chairList = new List<Chairs>();
        int num;

        foreach(var chair in Chairs)
        {
            if(chair.isEmpty)
            {
                index.Add(chair.index);
            }
        }

        for(int i=0; i<20; i++)
        {
            num = Random.Range(0, Chairs.Count);
            if(index.Contains(num))
            {
                chairList.Add(Chairs[num]);
                Chairs[num].isEmpty = false;
                index.Remove(num);
            }

            if (chairList.Count.Equals(3))
            {
                break;
            }
        }
                return chairList;
    }

    public Chairs EmptyOneChair()
    {
        int num;
        Chairs chairTransform;

        index.Clear();

        foreach (var chair in Chairs)
        {
            if (chair.isEmpty)
            {
                index.Add(chair.index);
            }
        }

        for (int i = 0; i < 10; i++)
        {
            num = Random.Range(0, Chairs.Count);
            if (index.Contains(num))
            {
                Chairs[num].isEmpty = false;
                chairTransform = Chairs[num];
                return chairTransform;
            }
        }

        Debug.Log("의자가없나");
        return null;

    }

    public void UpdateChair(Chairs chairs)
    {
        Chairs[chairs.index].isEmpty = true;
    }
}
