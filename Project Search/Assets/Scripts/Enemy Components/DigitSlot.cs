using System;
using System.Collections.Generic;
using UnityEngine;

public class DigitSlot : MonoBehaviour, IDraggableReceiver
{
    [SerializeField] private GameObject _hidePanel;
    [SerializeField] private ResourceDisplay _hiddenResourceDisplay;
    [SerializeField] private ResourceDisplay _guessedResourceDisplay;
    
    public Resource.Suit ResourceToGuess => _resourceToGuess;
    private Resource.Suit _resourceToGuess;

    private GuessedDigitTracker _guessedDigitTracker;
    private List<Resource.Suit> _guessedResources;
    private bool _guessed;

    private void Awake()
    {
        _hidePanel.SetActive(true);
        _guessedResources = new List<Resource.Suit>(Enum.GetValues(typeof(Resource.Suit)).Length);
        
    }

    public void SetGuessedDigitTracker(GuessedDigitTracker tracker)
    {
        _guessedDigitTracker = tracker;
    }

    public void SetSuit(Resource.Suit suit)
    {
        _resourceToGuess = suit;
        _hiddenResourceDisplay.ShowResource(suit);
    }

    public bool CanReceiveDraggable(Idraggable draggable)
    {
        if (draggable is not Resource resource)
            return false;
        
        if (_guessed)
            return false;
        
        return _guessedResources.Contains(resource.ResourceSuit) == false;
    }

    public void ReceiveDraggable(Idraggable draggable)
    {
        Resource resource = draggable as Resource;
        if (resource == null)
        {
            Debug.LogError("Something went wrong. Digit slot received an Idraggable it can't handle! ");
            return;
        }
        
        MakeAGuess(resource.ResourceSuit);
        resource.RemoveFromPlay();
    }

    private void MakeAGuess(Resource.Suit guess)
    {
        _guessedResources.Add(guess);
        
        if (guess == _resourceToGuess)
        {
            _hidePanel.SetActive(false);
            _guessedResourceDisplay.gameObject.SetActive(false);
            _guessed = true;
            _guessedDigitTracker.MarkSlotAsGuessed(this);
        }
        else
        {
            _guessedResourceDisplay.ShowResource(guess);
        }
    }
}
