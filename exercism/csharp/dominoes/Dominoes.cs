using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CA1050 // Declare types in namespaces
public static class Dominoes
#pragma warning restore CA1050 // Declare types in namespaces
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var edges = dominoes.ToList();
        if (edges.Count == 0)
            return true;
        if (edges.Count == 1)
            return edges[0].Item1 == edges[0].Item2;

        var degree = new Dictionary<int, int>();
        var graph = new Dictionary<int, HashSet<int>>();

        foreach (var (a, b) in edges)
        {
            // Grafo no dirigido: añadir arista a ambos lados
            if (!graph.ContainsKey(a)) graph[a] = [];
            if (!graph.ContainsKey(b)) graph[b] = [];
            graph[a].Add(b);
            graph[b].Add(a);

            // Contar grados
            degree[a] = degree.GetValueOrDefault(a) + 1;
            degree[b] = degree.GetValueOrDefault(b) + 1;
        }

        // Verificar que todos los grados sean pares
        if (degree.Values.Any(d => d % 2 != 0))
            return false;

        // Verificar que el grafo sea conexo (DFS o BFS)
        var visited = new HashSet<int>();
        var stack = new Stack<int>();
        var start = graph.Keys.First();
        stack.Push(start);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (!visited.Add(node)) continue;

            foreach (var neighbor in graph[node])
                if (!visited.Contains(neighbor))
                    stack.Push(neighbor);
        }

        // Asegurarse de que todos los nodos con al menos un borde fueron visitados
        return graph.Keys.All(k => visited.Contains(k));
    }
}