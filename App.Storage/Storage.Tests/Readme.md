﻿На данном этапе не проходят тесты требующие перестройки дерева

```textual grap representation

G1: 0 -> 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7 -> 8 -> 9
G2: 0 -> 1 -> 2 -> 3

```

должно быть следующим образом:
если сначала добавить G1 
потом при добавлении G2 найти наименьшего общего предка (в англ. литературе LCA)

```
LCA(G1, G2) = 2 = v(2)
```

потом в `v(2)` добавить `G2 - v(2)`