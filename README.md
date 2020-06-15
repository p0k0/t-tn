# _Tree data structure management_

**_Дано:_**

1. Не ориентированный граф G

2. pattern поиска - графа такой что:

    a) pattern - не ветвящийся путь

    aa) pattern - может и не быть подграфом G

**_Найти (Сделать) реализацию алгоритма_**:

можно поддерживать граф G:

1. добавлять новые pattern

2. искать совпадения по pattern
    (совпадения считаются верными
    если нашелся путь из вершины G
    частично или полностью равный pattern)

пример (частичного совпадения):

```graph notation
G: a1 -> a2 -> a3 -> a4
    \
      a5 -> a6

pattern: a1 -> a5 (буедт частичным совпадением)
pattern: a1 -> a6 (не буедт частичным совпадением)
```

и возвращать найденные варианты "пройденные"
до листьев

пример:

```graph notation
G: a1 -> a2 -> a3 -> a4
                \
                  -> a5 -> a6

pattern: a1 -> a2
find result:
1. a1 -> a2 -> a3 -> a4
2. a1 -> a2 -> a3 -> a5 -> a6
```

***

# Technical info

* main algorithm
* additional functions
* aproximal time eval at _O(n)_  notation

---

## main algorithm

1. Find equal history tail

2. Traverse to leaf (save leaf's)

3. Traverse to root from each saved leaf aggregating traversed path

## additional functions

1. build tree from string

2. merge trees by equal leading part

  example:

```graph notation
G1: a1 -> a2 -> a3
G2: a1 -> a2 -> a6

G3 will be merge result of G1 and G2 smth like this

G3: a1 -> a2 -> a3
            \ -> a6
```

## aproximal time eval at _O(n)_  notation

1. Find equal history tail

    * find required sub-tree head if G is not connected graph _O(n) < log2(n)_   
    (bin search in ordered array of _n_ head)
    * at founded head - traverse _s_ node until find history tail _O(n) < logX (n)_   
    at current subtree with n node, where X = max child degree

2. Traverse to leafs (save leaf's)

    * if at sub graph G1 contain _t_ leaf then _O(n) < t * logX (n)_   
    at current subtree with n node, where X = max child degree

3. Traverse to root from each saved leaf aggregating traversed path

    * if at sub graph G1 contain _t_ leaf then _O(n) < t * logX (n)_   
    at current subtree with n node, where X = max child degree
