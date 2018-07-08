using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NP.DataStructure;

public class BinaryHeapTest : MonoBehaviour {

	BinaryHeap<int> heap = new BinaryHeap<int>(delegate(int parent, int child) {
		return (parent >= child);
	});

	// Use this for initialization
	void Start () {

		heap.Add (3);
		heap.Add (6);
		heap.Add (1);
		heap.Add (2);
		heap.Add (7);
		heap.Add (4);
		heap.Add (5);
		heap.Add (10);
		heap.Add (8);
		heap.Add (11);
		heap.Add (9);
		heap.Add (25);
		heap.Add (43);
		heap.Add (33);
		heap.Add (27);
		heap.Add (17);
		PrintHeap (heap);

		heap.Remove ();
		heap.Remove ();
		heap.Remove ();
		heap.Remove ();
		PrintHeap (heap);
	}

	void PrintHeap(BinaryHeap<int> aHeap){
	
		int[] bHeap = aHeap.Heap;
		string str = "BinaryHeap priority: "+aHeap.Priority +"\n";

		for(int i=0;i<bHeap.Length;i++)
			str += bHeap[i]+"\n";

		Debug.Log (str);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
