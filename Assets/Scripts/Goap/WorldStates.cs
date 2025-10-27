using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string key;
    public int value;
}

public class WorldStates
{    
    public Dictionary<string, int> states;
    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }
    // Verifica se o estado existe no dicion�rio
    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }
    // Adiciona um estado ao dicion�rio
    public void AddState(string key, int value)
    {
        states[key] = value;
    }
    // Remove um estado do dicion�rio se ele existir
    public void RemoveState(string key)
    {
        if(states.ContainsKey(key)) { states.Remove(key); }
    }
    // Atualiza um estado no dicion�rio
    public void UpdateState(string key, int value)
    {
        // Se o estado j� existe, atualiza o valor
        if (states.ContainsKey(key))
        {
            states[key] += value; // Incrementa o valor existente
            // Se o valor for menor ou igual a zero, remove o estado
            if (states[key] <= 0) { RemoveState(key); }
        }
        // Se o estado n�o existe, adiciona-o
        else { states.Add(key, value); }
    }
    // Seta o valor de um estado (sem incrementar)
    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key)) { states[key] = value; }
        else { states.Add(key, value); }
    }
    // Retorna o valor de um estado
    public Dictionary<string, int> GetStates()
    {
        return states;
    }
}
