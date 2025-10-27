using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Alterar a classe para ser abstrata
public abstract class GoapAction : MonoBehaviour
{    
    public string actionName = "Action"; // Nome da a��o
    public float cost = 1f;              // Custo da a��o (tempo, recursos, etc.)
    public GameObject target;            // Local que a a��o deve ser executada
    public string targetTag;             // Se n�o houver target, busca por tag
    public float duration = 0f;          // Tempo que a a��o leva para ser conclu�da
    public NavMeshAgent agent;           // Agente de navega��o
    // WorldState � usado para setar as condicoes e efeitos no Inspector
    public WorldState[] preConditions; // Condi��es pr�vias para executar a a��o
    public WorldState[] afterEffects;  // Efeitos ap�s a execu��o da a��o
    // Os dicion�rios s�o usados para facilitar a manipula��o das condi��es e efeitos
    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;
    public WorldStates agentStates; // Estado do agente
    public bool performingAction = false; // Se a a��o est� sendo executada
    public GoapInventory inventory; // Invent�rio do agente

    // Construtor para inicializar os dicion�rios
    public GoapAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if(preConditions != null)
        {
            foreach(WorldState w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if(afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
        inventory = GetComponent<GoapAgent>().inventory;
        agentStates = GetComponent<GoapAgent>().personalStates;
    }
    // Placeholder para acionar a a��o sem testar
    public bool IsAchievable()
    {
        return true;
    }
    // Verifica se a a��o � poss�vel dado um conjunto de condi��es
    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> p in preconditions)
        {
            // Se a condi��o n�o est� nos estados, retorna falso
            if (!conditions.ContainsKey(p.Key))
                return false;
        }
        return true;
    }
    // Os m�todos abstratos abaixo s�o semelhantes ao Enter e Exit do FSM
    // PrePerform � chamado quando a a��o est� prestes a ser executada
    public abstract bool PrePerform();
    // PostPerform � chamado quando a a��o foi conclu�da
    public abstract bool PostPerform();
}
