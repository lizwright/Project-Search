using UnityEngine;

public class TooltipRequestor : MonoBehaviour, IHoverable
{
    [SerializeField] private Transform _tooltipPoint;

    private const float KHoverDuration = 1f;
    private bool _hovering;
    private float _hoverEnterTime;
    private bool _hasTooltip;

    private void Awake()
    {
        _hovering = false;
        _hasTooltip = false;
    }

    private void Update()
    {
        if (_hasTooltip)
        {
            if (_hovering)
                return;
            
            TooltipBox.Instance.Hide();
            _hasTooltip = false;
            return;
        }

        if (_hovering)
        {
            if (Time.time >= _hoverEnterTime + KHoverDuration)
            {
                TooltipBox.Instance.ShowAtPosition("message goes here", _tooltipPoint.position);
                _hasTooltip = true;
            }
        }
    }
    public void OnHoverEnter()
    {
        _hovering = true;
        _hoverEnterTime = Time.time;
    }

    public void OnHoverExit()
    {
        _hovering = false;
    }
}
