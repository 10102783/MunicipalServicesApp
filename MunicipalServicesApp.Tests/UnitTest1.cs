using System;
using Xunit;
using MunicipalServicesApp;

namespace MunicipalServicesApp.Tests
{
    public class DataStructuresTests
    {
        [Fact]
        public void MinHeap_Insert_ExtractMin_ShouldReturnCorrectOrder()
        {
            // Arrange
            var heap = new MinHeap();
            var request1 = new ServiceRequest(1, "Fix Water Pipe", "Pending", DateTime.Now);
            var request2 = new ServiceRequest(2, "Repair Streetlight", "In Progress", DateTime.Now.AddDays(1));
            var request3 = new ServiceRequest(3, "Clean Park", "Completed", DateTime.Now.AddDays(2));

            // Act
            heap.Insert(request1);
            heap.Insert(request2);
            heap.Insert(request3);

            // Assert
            var minRequest = heap.ExtractMin();
            Assert.Equal(1, minRequest.RequestID);  // Should return the request with the smallest ID
        }

        [Fact]
        public void BinarySearchTree_Search_ShouldReturnCorrectNode()
        {
            // Arrange
            var bst = new BinarySearchTree();
            var request1 = new ServiceRequest(1, "Fix Water Pipe", "Pending", DateTime.Now);
            var request2 = new ServiceRequest(2, "Repair Streetlight", "In Progress", DateTime.Now.AddDays(1));

            bst.Insert(request1);
            bst.Insert(request2);

            // Act
            var foundRequest = bst.Search(2);  // Searching for Request ID 2

            // Assert
            Assert.NotNull(foundRequest);
            Assert.Equal(2, foundRequest.RequestID);  // Should find the request with ID 2
        }
    }
}
