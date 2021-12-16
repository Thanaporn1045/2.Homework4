using System;
using System.Collections.Generic;

namespace graph
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] AllCitiesArray;
            int AllCities, thisCity = 1;

            AllCities = int.Parse(Console.ReadLine());
            AllCitiesArray = new string[AllCities];

            int[,] graph = new int[AllCitiesArray.Length, AllCitiesArray.Length];

            for (int a = 0; a < AllCities; a++)
            {
                AllCitiesArray[a] = Console.ReadLine();
            }
            
            do
            {
                for (int b = 0; b < thisCity; b++)
                {
                    //Console.Write("{0}-->{1} : ", AllCitiesArray[b], AllCitiesArray[thisCity]);
                    graph[thisCity, b] = int.Parse(Console.ReadLine());
                    graph[b, thisCity] = graph[thisCity, b];
                }
                thisCity++;
            } while (thisCity != AllCities);
            
            int[] ShortestDistanceArray;
            ShortestDistanceArray = Dijkstra(graph, 0, AllCities);
            PrintShortestPath(ShortestDistanceArray, AllCitiesArray);
        }


        static int[] Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && graph[u, v] != -1 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    { 
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }

            return (distance);
        }
        static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
        static void PrintShortestPath(int[] ShortestDistanceArray, string[] AllCitiesArray )
        {
            string DestinationCity; int CityPosition=0;
            DestinationCity = Console.ReadLine();
            for(int i =0;i<AllCitiesArray.Length; i++)
            {
                if(DestinationCity==AllCitiesArray[i])
                {
                    CityPosition = i; break;
                }
            }

            Console.WriteLine(ShortestDistanceArray[CityPosition]);
        }
    }
}
