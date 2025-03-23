using UnityEngine;

public class GaugeMarker : MonoBehaviour
{
    [SerializeField] private GameObject _paidOverlay;

    private bool _paid;

    private void Awake()
    {
        _paidOverlay.SetActive(false);
        _paid = false;
    }

    public void ShowPaid()
    {
        if (_paid == true)
            return;
        
        _paidOverlay.SetActive(true);
        _paid = true;

    }
    
    public void ShowUnpaid()
    {
        if (_paid == false)
            return;
        
        _paidOverlay.SetActive(false);
        _paid = false;
    }
}
