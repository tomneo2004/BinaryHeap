using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NP.DataStructure{

	public class BinaryHeap<T> {

		T[] _heap;
		public T[] Heap{get{ return (T[])_heap.Clone();}}

		public delegate bool Swap(T parent, T child);
		public Swap _swap;

		/**
		 * Swap delegate method must be provided.
		 * 
		 * Swap delegate method give parent and child as parameters
		 * 
		 * In a Min-Heap return true in Swap method implementation if parent greater than or
		 * equal to child. As Min-Heap parent have always been smaller than child.
		 * e.g parent >= child
		 * 
		 * In a Max-Heap return false in Swap method implementation if child greater than or
		 * equal to parent. As Max-Heap parent have always been bigger than child.
		 * e.g parent <= child
		 **/
		public BinaryHeap(Swap swapCheck){

			_heap = new T[0];

			if (swapCheck == null)
				Debug.LogAssertion ("BinaryHeap must have comparsion method");
			_swap = swapCheck;
		}

		/**
		 * Return first element in heap
		 **/
		public T GetElement(){
		
			if (_heap == null)
				return default(T);

			if (_heap.Length <= 0)
				return default(T);

			return _heap [0];
		}

		/**
		 * Add element into heap
		 **/
		public void Add(T element){

			int totalElements = _heap.Length + 1;

			//add element to heap
			T[] tempHeap = new T[totalElements];
			_heap.CopyTo (tempHeap, 0);
			tempHeap [totalElements - 1] = element;
			_heap = tempHeap;

			//The pointer which point to the last element in a set of
			//elements of binary tree that should be checking
			int b_pointerIndex = totalElements;

			//Binary heap start index from 1 not 0
			//Every check we move pointer forward
			while (b_pointerIndex != 1) {

				//Each element has 2 childs both location are
				//element's location * 2
				//element's location * 2 + 1
				//We find parent index of 2 child
				int b_parentIndex = b_pointerIndex / 2;

				//should element swap
				if (_swap (_heap [b_parentIndex - 1], _heap [b_pointerIndex - 1])) {

					T tempElement = _heap [b_pointerIndex - 1];
					_heap [b_pointerIndex - 1] = _heap [b_parentIndex - 1];
					_heap [b_parentIndex - 1] = tempElement;

					//move pointer forward to upper layer of binary tree
					b_pointerIndex = b_parentIndex;

				} else {
				
					break;
				}
			}
		}
			
	}
}

