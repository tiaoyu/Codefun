# Codefun

## 1 语言

### c#

闭包
反射
委托
* 委托在内存中是什么结构
* 委托是类还是方法

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

### 贪心
### 字典序
### 动态规划
### 数学
* 取石子问题
* [希尔伯特旅馆悖论(Hilbert's paradox of the Grand Hotel)](https://zhuanlan.zhihu.com/p/27078717)
* 正多边形最小外接正方形的边长计算
若边长为4的倍数4n，则外接正方形边长为 $\sum_{i=1}^{n-1}\cos((2\pi/4n)*i)$
若边长为4的倍数+2，则外接正方形边长为 $2*\cos(2\pi/(4n+2)/2)*\sum_{i=1}^{n}\cos((2\pi/(4n+2))*i)$

## 4 网络

### TCP
### UDP

## 存储
### Mysql索引

## 5 设计模式

### 单例模式

### ECS结构

## 6 架构

### 并发并行
### RPC
### 消息队列
### 分布式缓存机制
### zookeeper应用

## 7 其他
### 协程
协程，就是将当前函数的执行顺序给改变了，最终还是在同一线程中。
* 汇编的寄存器和远跳指令
* TAOCP卷一的coroutine
### 内核态/用户态
内核态和用户态切换会造成什么资源的浪费？
