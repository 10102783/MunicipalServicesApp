using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public class MinHeap
    {
        private List<ServiceRequest> heap;

        public MinHeap()
        {
            heap = new List<ServiceRequest>();
        }

        // Insert a service request into the heap
        public void Insert(ServiceRequest request)
        {
            heap.Add(request);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[(index - 1) / 2].RequestID > heap[index].RequestID)
            {
                Swap(index, (index - 1) / 2);
                index = (index - 1) / 2;
            }
        }

        private void Swap(int index1, int index2)
        {
            var temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }

        // Extract the minimum (root) element from the heap
        public ServiceRequest ExtractMin()
        {
            if (heap.Count == 0)
                return null;

            var min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);

            return min;
        }

        private void HeapifyDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if (leftChild < heap.Count && heap[leftChild].RequestID < heap[smallest].RequestID)
                smallest = leftChild;

            if (rightChild < heap.Count && heap[rightChild].RequestID < heap[smallest].RequestID)
                smallest = rightChild;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        // Method to check if a service request is already in the heap
        public bool Contains(ServiceRequest request)
        {
            foreach (var item in heap)
            {
                if (item.RequestID == request.RequestID)
                {
                    return true;
                }
            }
            return false;
        }

        // Remove a specific service request from the heap
        public bool Remove(ServiceRequest request)
        {
            int index = heap.FindIndex(r => r.RequestID == request.RequestID);
            if (index == -1)
            {
                return false;  // Request not found
            }

            // Move the last element to the index of the element to be removed
            heap[index] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            // Restore the heap property
            HeapifyDown(index);
            HeapifyUp(index);

            return true; // Successfully removed the request
        }
    }
}

