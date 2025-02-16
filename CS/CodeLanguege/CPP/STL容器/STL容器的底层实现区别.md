C++ 的 STL 容器在底层实现中使用了不同的数据结构，这些实现方式决定了它们在插入、查找、删除等操作中的性能特性。以下是常见 STL 容器的底层实现及其区别：

### 1. `vector`

- **底层实现**：动态数组
- **特点**：
  - 连续的内存布局，支持高效的随机访问（通过索引访问元素的时间复杂度为 \(O(1)\)）。
  - 插入和删除操作在末尾处较快（摊销 \(O(1)\)），在中间或开头则需要移动大量元素，时间复杂度为 \(O(n)\)。
  - 当容器空间不足时会自动扩容，通常会以 1.5 倍或 2 倍的大小进行扩展，但会导致重新分配和拷贝，影响效率。

### 2. `deque`

- **底层实现**：分段数组（块指针数组）
- **特点**：
  - 支持在两端快速插入和删除元素，平均时间复杂度为 \(O(1)\)。
  - 内存并不连续，适合需要在两端频繁插入和删除的场景。
  - 随机访问的效率比 `vector` 稍慢，但仍然是 \(O(1)\) 的复杂度。

### 3. `list`

- **底层实现**：双向链表
- **特点**：
  - 不连续的内存布局，每个节点包含指向前后节点的指针，插入和删除操作在任意位置都为 \(O(1)\)。
  - 不支持随机访问，需要顺序遍历，查找特定位置元素的时间复杂度为 \(O(n)\)。
  - 适用于需要频繁在中间插入或删除的场景。

### 4. `forward_list`

- **底层实现**：单向链表
- **特点**：
  - 与 `list` 相似，但只能在前后遍历，单向链表节省了内存（每个节点只有一个指向下一个节点的指针）。
  - 插入和删除操作在任意位置都为 \(O(1)\)，但不支持双向遍历。
  - 适合内存受限场景或仅需单向遍历的情况。

### 5. `map` 和 `set`

- **底层实现**：红黑树（自平衡的二叉搜索树）
- **特点**：
  - 键按顺序存储（`map` 和 `set` 默认按升序）。
  - 插入、查找、删除的平均和最坏时间复杂度为 \(O(\log n)\)。
  - `map` 存储键值对 (`key-value`)，而 `set` 仅存储键（即只需要值没有映射的场景）。
  - 适合需要按序存储并且高效查找的场景。

### 6. `unordered_map` 和 `unordered_set`

- **底层实现**：哈希表
- **特点**：
  - 元素无序存储，插入、查找、删除的平均时间复杂度为 \(O(1)\)，但最坏情况下（例如哈希碰撞严重时）退化为 \(O(n)\)。
  - `unordered_map` 适用于键值对存储，`unordered_set` 仅存储键。
  - 适合不需要顺序的快速查找场景，但要注意哈希函数的设计对性能的影响。

### 7. `stack`

- **底层实现**：通常是 `deque`，但也可以用 `vector` 或 `list`
- **特点**：
  - 适用于后进先出 (LIFO) 的场景。
  - 只允许访问栈顶元素，插入和删除的时间复杂度为 \(O(1)\)。

### 8. `queue`

- **底层实现**：通常是 `deque`
- **特点**：
  - 适用于先进先出 (FIFO) 的场景。
  - 只允许访问队首和队尾元素，插入和删除的时间复杂度为 \(O(1)\)。

### 9. `priority_queue`

- **底层实现**：堆（通常是最大堆，用于实现最大优先队列）
- **特点**：
  - 元素按优先级排序，默认最大堆（即优先级最高的元素在顶部）。
  - 插入和删除（取出最大元素）的时间复杂度为 \(O(\log n)\)。
  - 适合需要频繁获取最大值或最小值的场景。

### 总结对比

| 容器类型           | 底层实现           | 插入删除效率       | 随机访问效率      | 元素有序性 |
|------------------|------------------|------------------|-----------------|----------|
| `vector`         | 动态数组          | 末尾高效 \(O(1)\) | \(O(1)\)       | 有序      |
| `deque`          | 分段数组          | 两端高效 \(O(1)\) | \(O(1)\)       | 无序      |
| `list`           | 双向链表          | 任意位置 \(O(1)\)  | \(O(n)\)       | 按插入顺序 |
| `forward_list`   | 单向链表          | 任意位置 \(O(1)\)  | \(O(n)\)       | 按插入顺序 |
| `map`/`set`      | 红黑树            | \(O(\log n)\)    | \(O(\log n)\)  | 有序      |
| `unordered_map`/`unordered_set` | 哈希表 | \(O(1)\) 平均  | \(O(1)\) 平均 | 无序      |
| `stack`          | `deque`/`vector` | 栈顶 \(O(1)\)     | 不支持         | 无序      |
| `queue`          | `deque`          | 队首队尾 \(O(1)\)  | 不支持         | 无序      |
| `priority_queue` | 堆               | \(O(\log n)\)    | 不支持         | 无序      |

在使用 STL 容器时，应根据需求选择合适的数据结构，例如：频繁的插入、删除用 `list`；需要按顺序存储的键值对用 `map`；希望无序且快速查找时选 `unordered_map`。