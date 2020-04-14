using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructure
{
    public class AVLNode<T> where T : IComparable
    {
        public T t;
        public AVLNode<T> left;
        public AVLNode<T> right;
        public int deep;
    }

    public class AVLTree<T> where T : IComparable
    {
        private AVLNode<T> Root;
        public void Insert(T t)
        {
            void insert(ref AVLNode<T> root, T t)
            {
                if (root == null)
                {
                    root = new AVLNode<T>
                    {
                        t = t
                    };
                    root.deep = 1;
                    return;
                }

                if (root.t.CompareTo(t) == 0)
                    return;

                if (t.CompareTo(root.t) < 0)
                {
                    insert(ref root.left, t);
                }
                else if (t.CompareTo(Root.t) > 0)
                {
                    insert(ref root.right, t);
                }
                // 计算深度
                var leftDeep = root.left == null ? 0 : root.left.deep;
                var rightDeep = root.right == null ? 0 : root.right.deep;
                root.deep = 1 + Math.Max(leftDeep, rightDeep);

                if (leftDeep - rightDeep > 1)
                {
                    RightRotation(root);
                    // 左旋或右旋后只影响当前两层节点的深度 所以只需重新计算当前节点的左右节点深度即可
                    CalDeepOfTowFloor(root);
                    //Rebalance(root);
                }
                else if (leftDeep - rightDeep < -1)
                {
                    LeftRotation(root);
                    // 左旋或右旋后只影响当前两层节点的深度 所以只需重新计算当前节点的左右节点深度即可
                    CalDeepOfTowFloor(root);
                    //Rebalance(root);
                }
            }
            insert(ref Root, t);
        }

        /// <summary>
        /// 左旋
        /// </summary>
        /// <param name="root"></param>
        public void LeftRotation(AVLNode<T> root)
        {
            var tmp = root.left;
            var tmpk = root.t;

            root.left = root.right;
            root.right = root.left.right;
            root.left.right = root.left.left;

            root.left.left = tmp;
            root.t = root.left.t;
            root.left.t = tmpk;
        }

        /// <summary>
        /// 右旋
        /// </summary>
        /// <param name="root"></param>
        public void RightRotation(AVLNode<T> root)
        {
            var tmp = root.right;
            var tmpk = root.t;

            root.right = root.left;
            root.left = root.right.left;
            root.right.left = root.right.right;

            root.right.right = tmp;
            root.t = root.right.t;
            root.right.t = tmpk;
        }

        /// <summary>
        /// 计算当前两层节点的深度
        /// </summary>
        /// <param name="root"></param>
        public void CalDeepOfTowFloor(AVLNode<T> root)
        {
            if (root.left != null)
                root.left.deep = 1 + Math.Max(root.left.right == null ? 0 : root.left.right.deep, root.left.left == null ? 0 : root.left.left.deep);

            if (root.right != null)
                root.right.deep = 1 + Math.Max(root.right.right == null ? 0 : root.right.right.deep, root.right.left == null ? 0 : root.right.left.deep);

            root.deep = 1 + Math.Max(root.left == null ? 0 : root.left.deep, root.right == null ? 0 : root.right.deep);
        }

        /// <summary>
        /// 重新计算深度 保持树的平衡
        /// </summary>
        /// <param name="root"></param>
        public void Rebalance(AVLNode<T> root)
        {
            static void rebalance(AVLNode<T> root)
            {
                if (root.left == null && root.right == null)
                {
                    root.deep = 1;
                    return;
                }
                if (root.left != null)
                    rebalance(root.left);
                if (root.right != null)
                    rebalance(root.right);
                root.deep = 1 + Math.Max(root.left == null ? 0 : root.left.deep, root.right == null ? 0 : root.right.deep);
            }
            rebalance(root);
        }

        /// <summary>
        /// 移除节点
        /// 移除后 若其左节点较深则取左节点的最深右节点替代当前节点；若右节点较深则取右节点的最深左节点替代当前节点
        /// </summary>
        /// <param name="t"></param>
        public void Remove(T t)
        {
            void remove(AVLNode<T> root, T t)
            {
                if (root == null)
                    return;
                if (t.CompareTo(root.t) == 0)
                {
                    var leftDeep = root.left == null ? 0 : root.left.deep;
                    var rightDeep = root.right == null ? 0 : root.right.deep;
                    if (leftDeep != 0 && leftDeep - rightDeep >= 0)
                    {
                        var tmp = root.left;
                        while (tmp.right != null)
                        {
                            tmp = tmp.right;
                        }
                        tmp.left = root.left;
                        tmp.right = root.right;
                    }
                    else
                    {
                        var tmp = root.right;
                        while (tmp.left != null)
                        {
                            tmp = tmp.left;
                        }
                        tmp.left = root.left;
                        tmp.right = root.right;
                    }
                }
                else if (t.CompareTo(root.t) < 0)
                {
                    if (root.left != null)
                    {
                        if (root.left.t.CompareTo(t) == 0)
                        {
                            // 找到要删除的节点 优先从较深的那个子节点中拿一个节点替代当前要删除的节点
                            var leftDeep = root.left.left == null ? 0 : root.left.left.deep;
                            var rightDeep = root.left.right == null ? 0 : root.left.right.deep;
                            if (leftDeep == 0 && leftDeep == 0)
                            {
                                root.left = null;
                            }
                            if (leftDeep != 0 && leftDeep - rightDeep >= 0)
                            {
                                var tmp = root.left.left;
                                var tmpr = tmp.right;
                                if (tmpr == null)
                                {
                                    tmp.right = root.left.right;
                                    root.left = tmp;
                                }
                                else
                                {
                                    while (tmpr.right != null)
                                    {
                                        tmp = tmpr;
                                        tmpr = tmpr.right;
                                    }
                                    tmp.right = null;

                                    tmpr.left = root.left.left;
                                    tmpr.right = root.left.right;
                                    root.left = tmpr;
                                }
                            }
                            else
                            {
                                var tmp = root.left.right;
                                var tmpr = tmp.left;
                                if (tmpr == null)
                                {
                                    tmp.left = root.left.left;
                                    root.left = tmp;
                                }
                                else
                                {
                                    while (tmpr.left != null)
                                    {
                                        tmp = tmpr;
                                        tmpr = tmpr.left;
                                    }
                                    tmp.right = null;

                                    tmpr.left = root.left.left;
                                    tmpr.right = root.left.right;
                                    root.left = tmpr;
                                }
                            }
                        }
                        else remove(root.left, t);
                    }

                }
                else if (t.CompareTo(root.t) > 0)
                {
                    if (root.right != null)
                    {
                        if (root.right.t.CompareTo(t) == 0)
                        {
                            // 找到要删除的节点 优先从较深的那个子节点中拿一个节点替代当前要删除的节点
                            var leftDeep = root.right.left == null ? 0 : root.right.left.deep;
                            var rightDeep = root.right.right == null ? 0 : root.right.right.deep;
                            if (leftDeep == 0 && rightDeep == 0)
                            {
                                root.right = null;
                            }
                            else if (leftDeep != 0 && leftDeep - rightDeep >= 0)
                            {
                                var tmp = root.right.left;
                                var tmpr = tmp.right;
                                if (tmpr == null)
                                {
                                    tmp.left = root.right.right;
                                    root.right = tmp;
                                }
                                while (tmpr.right != null)
                                {
                                    tmp = tmpr;
                                    tmpr = tmpr.right;
                                }
                                tmp.right = null;

                                tmpr.left = root.right.left;
                                tmpr.right = root.right.right;
                                root.right = tmpr;
                            }
                            else
                            {
                                var tmp = root.right.right;
                                var tmpr = tmp.left;
                                if (tmpr == null)
                                {
                                    tmp.left = root.right.left;
                                    root.left = tmp;
                                }
                                while (tmpr.left != null)
                                {
                                    tmp = tmpr;
                                    tmpr = tmpr.left;
                                }
                                tmp.right = null;

                                tmpr.left = root.right.left;
                                tmpr.right = root.right.right;
                                root.right = tmpr;
                            }
                        }
                        else
                            remove(root.right, t);
                    }
                }
            }
            remove(Root, t);
        }

        /// <summary>
        /// 以满二叉树输出 节点为null输出-1
        /// </summary>
        /// <param name="root"></param>
        public void Print()
        {
            var queue = new Queue<AVLNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    Console.Write("-1");
                    continue;
                }
                Console.Write(node.t);
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            Console.WriteLine();
        }

    }
}
