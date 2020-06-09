tree data structurer management

Дано:

1. не ориентированный граф G

2. pattern поиска - графа такой что:
  a. pattern - не ветвящийся путь
  b. pattern - может и не быть подграфом G

Найти (Сделать) реализацию алгоритма:

можно поддерживать граф G:
a. добавлять новые pattern
aa. искать совпадения по pattern 
    (совпадения считаются верными 
    если нашелся путь из вершины G 
    частично или полностью равный pattern)

    пример (частичного совпадения):
    G: a1 -> a2 -> a3 -> a4
        \
         a5 -> a6
    
    pattern: a1 -> a5 (буедт частичным совпадение)
    pattern: a1 -> a6 (не буедт частичным совпадение)

    и возвращать найденные варианты "пройденные"
    до листьев

    пример
    G: a1 -> a2 -> a3 -> a4
                    \
                      -> a5 -> a6
    
    pattern: a1 -> a2
    find result:
    1. a1 -> a2 -> a3 -> a4
    2. a1 -> a2 -> a3 -> a5 -> a6



main algorithm

-----

1.Find equal history tail

2.Traverse to leaf (save leaf's)

3.Traverse to root from each saved leaf aggregating traversed path


additional functions

-----

1. build tree from string

2. merge trees by equal leading part
  example:
  G1: a1 -> a2 -> a3
  G2: a1 -> a2 -> a6
  G3 will be merge result of G1 and G2
  smth like this
  G3: a1 -> a2 -> a3
             \ -> a6