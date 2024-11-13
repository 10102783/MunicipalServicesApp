namespace MunicipalServicesApp
{
    public class BinarySearchTree
    {
        private class Node
        {
            public ServiceRequest Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(ServiceRequest data)
            {
                Data = data;
                Left = Right = null;
            }
        }

        private Node root;

        // Insert a ServiceRequest into the BinarySearchTree
        public void Insert(ServiceRequest request)
        {
            root = InsertRec(root, request);
        }

        private Node InsertRec(Node root, ServiceRequest request)
        {
            if (root == null)
            {
                root = new Node(request);
                return root;
            }

            if (request.RequestID < root.Data.RequestID)
                root.Left = InsertRec(root.Left, request);
            else if (request.RequestID > root.Data.RequestID)
                root.Right = InsertRec(root.Right, request);

            return root;
        }

        // Delete a ServiceRequest from the tree
        public void Delete(int requestID)
        {
            root = DeleteRec(root, requestID);
        }

        private Node DeleteRec(Node root, int requestID)
        {
            if (root == null)
                return root;

            // Find the node to be deleted
            if (requestID < root.Data.RequestID)
                root.Left = DeleteRec(root.Left, requestID);
            else if (requestID > root.Data.RequestID)
                root.Right = DeleteRec(root.Right, requestID);
            else
            {
                // Node with only one child or no child
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                // Node with two children: get the inorder successor
                root.Data = MinValue(root.Right);

                // Delete the inorder successor
                root.Right = DeleteRec(root.Right, root.Data.RequestID);
            }

            return root;
        }

        private ServiceRequest MinValue(Node node)
        {
            ServiceRequest min = node.Data;
            while (node.Left != null)
            {
                min = node.Left.Data;
                node = node.Left;
            }
            return min;
        }

        // Search for a ServiceRequest by its RequestID
        public ServiceRequest Search(int requestID)
        {
            return SearchRec(root, requestID);
        }

        private ServiceRequest SearchRec(Node root, int requestID)
        {
            if (root == null || root.Data.RequestID == requestID)
                return root?.Data;

            if (requestID < root.Data.RequestID)
                return SearchRec(root.Left, requestID);
            else
                return SearchRec(root.Right, requestID);
        }

        // Check if the tree contains a ServiceRequest with the specified RequestID
        public bool Contains(ServiceRequest request)
        {
            return ContainsRec(root, request);
        }

        private bool ContainsRec(Node root, ServiceRequest request)
        {
            if (root == null)
                return false;

            if (root.Data.RequestID == request.RequestID)
                return true;

            if (request.RequestID < root.Data.RequestID)
                return ContainsRec(root.Left, request);
            else
                return ContainsRec(root.Right, request);
        }
    }
}
