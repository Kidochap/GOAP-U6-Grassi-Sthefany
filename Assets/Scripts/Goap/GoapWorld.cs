using System.Collections.Generic;
using UnityEngine;

public sealed class GoapWorld
{
    // Inst�ncia singleton
    private static readonly GoapWorld instance = new GoapWorld();
    // Estado global do mundo
    private static WorldStates world;
    // Fila de testers
    private static Queue<GameObject> testers;
    // Fila de cub�culos
    private static Queue<GameObject> cubicles;
    // Construtor est�tico para inicializar o estado do mundo
    static GoapWorld()
    {
        world = new WorldStates();
        testers = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        // Popula a fila de cub�culos com os objetos na cena
        GameObject[] cubs = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubs) { cubicles.Enqueue(c); }
        // Informa ao mundo a quantidade de cub�culos livres
        if (cubicles.Count > 0) { world.AddState("FreeCubicle", cubicles.Count); }
    }
    // Construtor privado para evitar inst�ncia externa
    private GoapWorld() { }
    // Propriedade para acessar a inst�ncia singleton
    public static GoapWorld Instance { get { return instance; } }
    // M�todo para acessar o estado global do mundo
    public WorldStates GetWorld() { return world; }

    // M�todos para gerenciar a fila de testers
    public void AddTester(GameObject tester)
    {
        testers.Enqueue(tester);
    }
    public GameObject RemoveTester()
    {
        if (testers.Count <= 0) return null;
        return testers.Dequeue();
    }
    // Gerencia a fila de cub�culos
    public void AddCubicle(GameObject cubicle)
    {
        cubicles.Enqueue(cubicle);
    }
    public GameObject RemoveCubicle()
    {
        if (cubicles.Count <= 0) return null;
        return cubicles.Dequeue();
    }
}
