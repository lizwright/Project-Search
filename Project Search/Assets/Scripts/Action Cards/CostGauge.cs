using UnityEngine;

public class CostGauge : MonoBehaviour
{

    public bool IsFull => _currentCost >= _targetCost;
    public bool OnFinalMarker => _currentCost == _targetCost - 1;
    
    [SerializeField] private GameObject _gaugeMarkerTemplate;
    [SerializeField] private CenterHorizontalLayout _markerHolder;

    private int _targetCost;
    private int _currentCost;
    private GaugeMarker[] _markers;
    
    public void Initialise(int cost)
    {
        _targetCost = cost;
        _currentCost = 0;
        CreateMarkers(cost);
        UpdateMarkers();
    }

    public void PayCost(int value = 1)
    {
        _currentCost += value;
        UpdateMarkers();
    }
    
    private void CreateMarkers(int amount)
    {
        _markerHolder.RemoveChildren(transform);
        
        _markers = new GaugeMarker[amount];
        
        for (int i = 0; i < amount; i++)
        {
            _markers[i] = Instantiate(_gaugeMarkerTemplate, _markerHolder.transform).GetComponent<GaugeMarker>();
        }
        
        _markerHolder.Reposition(_markers);
    }
    
    private void UpdateMarkers()
    {
        for (int i = 0; i < _markers.Length; i++)
        {
            if (i <= _currentCost -1)
            {
                _markers[i].ShowPaid();
            }
            else
            {
                _markers[i].ShowUnpaid();
            }
        }
    }
    
}
