# Codefun

## 1 语言

### c#基础

1. 值类型/引用类型
：值类型在栈空间分配内存，引用类型在堆上分配内存且在栈上保留引用
2. 装箱/拆箱
：装箱指的是值类型转为引用类型，拆箱是引用类型转为值类型
3. string是值类型还是引用类型
：string是引用类型
4. stringbuilder与string区别
：一个是链式内存分配，一个是整块内存分配
5. async/await用法
：async用来声明一个方法是异步的，await 用来等待一个异步调用的结果，如果一个异步过程在await之前就已经完成了，则当前线程不会在await处阻塞；否则当前线程执行到await时会阻塞住。
6. 线程（thread/task）用法
var t = new Thread(()=>{});t.Start();t.Join();
Task.Run(()=>{}).Wait();
7.  mutex用法
:
8. 信号量用法
9. TCP三次握手/TCP TIME_WAIT状态
10. A*寻路，dij最短路径

* C#的值类型可以实现接口吗？
：C#的值类型可以实现接口
闭包
反射
委托
* 委托在内存中是什么结构
* 委托是类还是方法

### c++基础
#### STL相关内容
#### vector 迭代器

#### 指针/引用
#### 虚函数/虚表
#### 模板函数（泛型）
#### 智能指针
#### c++各版本的
#### linux下c++调试方式

### go基础


### python基础

## 2 数据结构

枚举类IEnumertor的实现

### 数组
* List 内部实现
List内部基础数据结构是数组，构造时默认数组大小为0
每次Add时，都会判断是否需要扩容，
数组为空时，扩容时增加4个大小；数组不空时，每次扩容翻一倍，如果一倍超过int最大值，则仅扩1个大小
每次扩容时，会new新数组，并且进行数组拷贝，将旧数组拷贝到新数组中
Remove、Insert等都会引发拷贝操作

### 字典
Dictionary 内部实现

### 集合
HashSet 内部实现
HashSet内部基础结构是数组，构造参数为零时不会分配内存

### Hashtable
Hashtable 内部实现
基础数据结构是bucket, bucket数组来存储数据
* new Hashtable():
capacity 初始化大小为 大于 3 / 0.72 的素数 = 5
即存储桶 bucket[5] buckets 初始化大小为5
负载大小为 loadsize = 5 * 0.72 = 3 即buckets大小超过loadsize就需要扩容
* Add(key, value)
通过GetHashCode % size 来判定需要插入的位置
*

* double hash？双重散列表法？
* Object上的GetHashCode方法底层如何实现的？
猜测和CLR有关，每个实例都有自己的hashcode，在创建出来时就带上了
* 开放定址法？
用来处理hash地址冲突时，使用的策略

### 链表

### 二叉树
每个节点最多有两个子节点的树形结构，联通图的一种
* B树
* 红黑树

### 四叉树

## 3 算法
### 3.1 贪心
### 3.2 字典序
### 3.3 动态规划
### 3.4 单调栈

链接：https://leetcode-cn.com/problems/trapping-rain-water

### 3.5 数学
* 取石子问题
* [希尔伯特旅馆悖论(Hilbert's paradox of the Grand Hotel)](https://zhuanlan.zhihu.com/p/27078717)
* 正多边形最小外接正方形的边长计算
若边长为4的倍数4n，则外接正方形边长为 $\sum_{i=1}^{n-1}\cos((2\pi/4n)*i)$
若边长为4的倍数+2，则外接正方形边长为 $2*\cos(2\pi/(4n+2)/2)*\sum_{i=1}^{n}\cos((2\pi/(4n+2))*i)$
#### 3.5.1 矩阵
* 矩阵旋转变换
$$
\left[
\begin{matrix}
    cos\theta & -sin\theta \\
    sin\theta & cos\theta
\end{matrix}
\right] *
\left[
\begin{matrix}
    x \\
    y
\end{matrix}
\right]
$$
## 4 网络
### 4.1 TCP
#### TCP连接过程各个状态
#### 三次握手
#### 四次挥手
#### 滑动窗口
#### 拥塞控制
慢启动

### 4.2 UDP

## 5 存储
### 5.1 Mysql
#### mysql主从复制
#### mysql分库分表
### redis

## 6 设计模式

### 单例模式

### ECS结构

## 7 架构

### 并发并行
#### 多线程以及锁的使用
### RPC
### 消息队列
### 分布式缓存机制
### zookeeper应用

## 其他
### 协程
协程，就是将当前函数的执行顺序给改变了，最终还是在同一线程中。
* 汇编的寄存器和远跳指令
* TAOCP卷一的coroutine
### 内核态/用户态
内核态和用户态切换会造成什么资源的浪费？
