using System.Collections.Generic;
using UnityEngine;

public class ActionCardHolder : MonoBehaviour
{
    [SerializeField] private GameObject _actionCardTemplate;
    [SerializeField] private CenterHorizontalLayout _holder;
    [SerializeField] private List<ActionCardData> _debugActionData;

    private void Awake()
    {
        SpawnActionCards(_debugActionData);
    }

    public void SpawnActionCards(List<ActionCardData> actionData)
    {
        _holder.RemoveChildren(transform);
        
        ActionCard[] cards = new ActionCard[actionData.Count];
        
        for (int i = 0; i < actionData.Count; i++)
        {
            ActionCard card = Instantiate(_actionCardTemplate, _holder.transform).GetComponent<ActionCard>();
            card.Initialise(actionData[i]);
            cards[i] = card;
        }
        
        _holder.Reposition(cards);
    }
    
}
