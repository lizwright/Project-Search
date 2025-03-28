using System.Collections.Generic;
using UnityEngine;

public class ActionCardHolder : MonoBehaviour
{
    [SerializeField] private GameObject _actionCardTemplate;
    [SerializeField] private CenterHorizontalLayout _holder;
    [SerializeField] private List<ActionCardData> _debugActionData;

    private ActionCard[] _cards;
    private List<ActionCard> _outOfPlayCards;
    private Vector3 _outOfPlayPosition;

    private void Awake()
    {
        _outOfPlayCards = new List<ActionCard>(10);
        _outOfPlayPosition = new Vector3(10000, transform.position.y, transform.position.z);
        SpawnActionCards(_debugActionData);
    }

    public void SpawnActionCards(List<ActionCardData> actionData)
    {
        _holder.RemoveChildren(transform);
        
        _cards = new ActionCard[actionData.Count];
        
        for (int i = 0; i < actionData.Count; i++)
        {
            ActionCard card = Instantiate(_actionCardTemplate, _holder.transform).GetComponent<ActionCard>();
            card.Initialise(actionData[i], this);
            _cards[i] = card;
        }
        
        _holder.Reposition(_cards);
    }

    public void MakeCardOutOfPlay(ActionCard card)
    {
        card.transform.position = _outOfPlayPosition;
        _outOfPlayCards.Add(card);
    }

    public void RefreshCards()
    {
        foreach (ActionCard card in _outOfPlayCards)
        {
            card.Reset();
        }
        
        _outOfPlayCards.Clear();
        _holder.Reposition(_cards);
    }
    
}
