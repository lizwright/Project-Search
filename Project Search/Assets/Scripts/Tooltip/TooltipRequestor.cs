using UnityEngine;

public abstract class TooltipRequestor : MonoBehaviour, IHoverable
{
    [SerializeField] private Transform _tooltipPoint;

    private const float KHoverDuration = 0.75f;
    private bool _hovering;
    private float _hoverEnterTime;
    private bool _hasTooltip;

    protected abstract string GetMessage();
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
                TooltipBox.Instance.ShowAtPosition(GetMessage(), _tooltipPoint.position);
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
