using System;

namespace MunicipalServicesApp
{
    public class AVLTree
    {
        public class Node
        {
            public ServiceRequest Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(ServiceRequest data)
            {
                Data = data;
                Left = Right = null;
                Height = 1;
            }
        }

        private Node root;

        public void Insert(ServiceRequest request)
        {
            root = InsertRec(root, request);
        }

        private Node InsertRec(Node root, ServiceRequest request)
        {
            if (root == null)
                return new Node(request);

            if (request.RequestID < root.Data.RequestID)
                root.Left = InsertRec(root.Left, request);
            else if (request.RequestID > root.Data.RequestID)
                root.Right = InsertRec(root.Right, request);

            root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));

            int balance = GetBalance(root);

            // Left Left Case
            if (balance > 1 && request.RequestID < root.Left.Data.RequestID)
                return RightRotate(root);

            // Right Right Case
            if (balance < -1 && request.RequestID > root.Right.Data.RequestID)
                return LeftRotate(root);

            // Left Right Case
            if (balance > 1 && request.RequestID > root.Left.Data.RequestID)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Right Left Case
            if (balance < -1 && request.RequestID < root.Right.Data.RequestID)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private int GetHeight(Node node)
        {
            return node == null ? 0 : node.Height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

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
    }
}
