using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphManager : MonoBehaviour {

    public static GraphManager instance;
    const int MAX = 100;

    public Color[] colors;

    public GameObject graph6Panel;
    public GameObject graph7Panel;
    public GameObject graph9Panel;

    public GameObject[] graph6Nodes;
    public GameObject[] graph7Nodes;
    public GameObject[] graph9Nodes;


    private int unprocessed = 0;
    private int NNCount;
    private int[] NN;
    private int[] color;
    private int[] degree;

    public int[,] adjMatrix6 = { { 0, 0, 1, 1, 1, 1 },
                                 { 0, 0, 1, 0, 1, 0 },
                                 { 1, 1, 0, 0, 0, 0 },
                                 { 1, 0, 0, 0, 0, 1 },
                                 { 1, 1, 0, 0, 0, 1 },
                                 { 1, 0, 0, 1, 1, 0 } };

    public int[,] adjMatrix7 = { { 0, 1, 1, 1, 1, 1, 0 },
                                 { 1, 0, 1, 0, 1, 0, 0 },
                                 { 1, 1, 0, 0, 0, 0, 0 },
                                 { 1, 0, 0, 0, 0, 1, 1 },
                                 { 1, 1, 0, 0, 0, 1, 0 },
                                 { 1, 0, 0, 1, 1, 0, 1 },
                                 { 0, 0, 0, 1, 0, 1, 0 } };

    public int[,] adjMatrix9 = { { 0, 1, 1, 0, 0, 1, 0, 1, 0 },
                                 { 1, 0, 1, 0, 1, 0, 0, 0, 1 },
                                 { 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                                 { 0, 0, 0, 0, 0, 0, 1, 1, 0 },
                                 { 0, 1, 0, 0, 0, 1, 0, 0, 0 },
                                 { 1, 0, 0, 0, 1, 0, 1, 1, 1 },
                                 { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                                 { 1, 0, 0, 1, 0, 1, 0, 0, 0 },
                                 { 0, 1, 0, 0, 0, 1, 0, 0, 0 } };

	// Use this for initialization
	void Start () {

        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGraph(int graphID)
    {
        switch (graphID)
        {
            case 6:                
                graph6Panel.SetActive(true);
                graph7Panel.SetActive(false);
                graph9Panel.SetActive(false);
                Init(6, adjMatrix6);
                StartCoroutine(Coloring(6, adjMatrix6));
                break;
            case 7:                
                graph7Panel.SetActive(true);
                graph6Panel.SetActive(false);
                graph9Panel.SetActive(false);
                Init(7, adjMatrix7);
                StartCoroutine(Coloring(7, adjMatrix7));
                break;
            case 9:                
                graph9Panel.SetActive(true);
                graph7Panel.SetActive(false);
                graph6Panel.SetActive(false);
                Init(9, adjMatrix9);
                StartCoroutine(Coloring(9, adjMatrix9));
                break;
            default:
                break;
        }
    }

    void Init(int n, int[,] a)
    {
        color = new int[MAX];
        degree = new int[MAX];
        NN = new int[MAX];

        for (int i = 0; i < n; i++)
        {
            color[i] = 0; // be sure that at first, no vertex is colored
            degree[i] = 0; // count the degree of each vertex
            for (int j = 0; j < n; j++)
                if (a[i,j] == 1) // if i-th vertex is adjacent to another
                    degree[i]++; // increase its degree by 1
        }
        NNCount = 0; // number of element in NN set
        unprocessed = n;
    }

    IEnumerator Coloring(int n, int[,] a)
    {
        int x, y;
        int ColorNumber = 0;
        int VerticesInCommon = 0;
        while (unprocessed > 0) // while there is an uncolored vertex
        {
            x = MaxDegreeVertex(n); // find the one with maximum degree
            ColorNumber++;            
            color[x] = ColorNumber; // give it a new color   
            yield return new WaitForSeconds(0.5f);
            if (n == 6)
                graph6Nodes[x].GetComponent<Image>().color = colors[ColorNumber - 1];
            else if (n == 7)
                graph7Nodes[x].GetComponent<Image>().color = colors[ColorNumber - 1];
            else
                graph9Nodes[x].GetComponent<Image>().color = colors[ColorNumber - 1];

            unprocessed--;
            UpdateNN(ColorNumber, n, a); // find the set of non-neighbors of x
            while (NNCount > 0)
            {
                // find y, the vertex has the maximum neighbors in common with x
                // VerticesInCommon is this maximum number
                y = FindSuitableY(ColorNumber, VerticesInCommon, n, a);
                // in case VerticesInCommon = 0
                // y is determined that the vertex with max degree in NN
                if (VerticesInCommon == 0)
                    y = MaxDegreeInNN(n, a);
                // color y the same to x
                color[y] = ColorNumber;
                yield return new WaitForSeconds(0.5f);
                if (n == 6)
                    graph6Nodes[y].GetComponent<Image>().color = colors[ColorNumber - 1];
                else if (n == 7)
                    graph7Nodes[y].GetComponent<Image>().color = colors[ColorNumber - 1];
                else
                    graph9Nodes[y].GetComponent<Image>().color = colors[ColorNumber - 1];
                unprocessed--;
                UpdateNN(ColorNumber, n, a);
                // find the new set of non-neighbors of x
            }
        }

        //if (n == 6)
        //{
        //    for (int i = 0; i < n; i++)
        //        graph6Nodes[i].GetComponent<Image>().color = colors[color[i] - 1];
        //}
        //else if (n == 7)
        //{
        //    for (int i = 0; i < n; i++)
        //        graph7Nodes[i].GetComponent<Image>().color = colors[color[i] - 1];
        //}
        //else
        //    for (int i = 0; i < n; i++)
        //        graph9Nodes[i].GetComponent<Image>().color = colors[color[i] - 1];
    }

    int MaxDegreeVertex(int n)
    {
        int max = -1;
        int max_i = 0;
        for (int i = 0; i < n; i++)
            if (color[i] == 0)
                if (degree[i] > max)
                {
                    max = degree[i];
                    max_i = i;
                }
        return max_i;
    }

    // this function is for UpdateNN function
    // it reset the value of scanned array
    void scannedInit(int[] scanned, int n)
    {
        for (int i = 0; i < n; i++)
            scanned[i] = 0;
    }

    // this function updates NN array
    void UpdateNN(int ColorNumber, int n, int[,] a)
    {
        NNCount = 0;
        // firstly, add all the uncolored vertices into NN set
        for (int i = 0; i < n; i++)
            if (color[i] == 0)
            {
                NN[NNCount] = i;
                NNCount++; // when we add a vertex, increase the NNCount
            }
        // then, remove all the vertices in NN that
        // is adjacent to the vertices colored ColorNumber
        for (int i = 0; i < n; i++)
            if (color[i] == ColorNumber) // find one vertex colored ColorNumber
                for (int j = 0; j < NNCount; j++)
                    while (a[i,NN[j]] == 1 && NNCount!=0)
                    // remove vertex that adjacent to the found vertex
                    {
                        NN[j] = NN[NNCount - 1];
                        NNCount--; // decrease the NNCount
                    }
    }

    int FindSuitableY(int ColorNumber, int VerticesInCommon, int n, int[,] a)
    {
        int temp, tmp_y, y = 0;
        // array scanned stores uncolored vertices
        // except the vertex is being processing
        int[] scanned = new int[n];
        VerticesInCommon = 0;
        for (int i = 0; i < NNCount; i++) // check the i-th vertex in NN
        {
            // tmp_y is the vertex we are processing
            tmp_y = NN[i];
            // temp is the neighbors in common of tmp_y
            // and the vertices colored ColorNumber
            temp = 0;
            scannedInit(scanned, NNCount);
            //reset scanned array in order to check all 
            //the vertices if they are adjacent to i-th vertex in NN
            for (int x = 0; x < n; x++)
                if (color[x] == ColorNumber) // find one vertex colored ColorNumber
                    for (int k = 0; k < n; k++)
                        if (color[k] == 0 && scanned[k] == 0)
                            if (a[x,k] == 1 && a[tmp_y,k] == 1)
                            // if k is a neighbor in common of x and tmp_y
                            {
                                temp++;
                                scanned[k] = 1; // k is scanned
                            }
            if (temp > VerticesInCommon)
            {
                VerticesInCommon = temp;
                y = tmp_y;
            }
        }
        return y;
    }

    // find the vertex in NN of which degree is maximum
    int MaxDegreeInNN(int n, int[,]a)
    {
        int tmp_y = 0; // the vertex has the current maximum degree
        int temp, max = 0;
        for (int i = 0; i < NNCount; i++)
        {
            temp = 0;
            for (int j = 0; j < n; j++)
                if (color[j] == 0 && a[NN[i],j] == 1)
                    temp++;
            if (temp > max) // if the degree of vertex NN[i] is higher than tmp_y's one
            {
                max = temp; // assignment NN[i] to tmp_y
                tmp_y = NN[i];
            }
        }
        if (max == 0) // so all the vertices have degree 0
            return NN[0];
        else // exist a maximum, return it
            return tmp_y;
    }



}
