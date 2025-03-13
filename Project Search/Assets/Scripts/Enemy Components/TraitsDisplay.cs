using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TraitsDisplay : MonoBehaviour
{

    [SerializeField] private GameObject _traitTemplate;
    [SerializeField] private CenterHorizontalLayout _layout;

    public void DisplayTraits(List<Trait> traits)
    {
        RemoveExistingTraits();

        Bounds[] bounds = new Bounds[traits.Count];
        Transform[] traitTransforms = new Transform[traits.Count];

        for (int i = 0; i < traits.Count; i++)
        {
            GameObject traitObj = Instantiate(_traitTemplate, transform.position, quaternion.identity, transform);
            bounds[i] = traitObj.GetComponent<Collider2D>().bounds;
            traitTransforms[i] = traitObj.transform;
            TraitIcon traitIcon = traitObj.GetComponent<TraitIcon>();
            traitIcon.SetIcon(traits[i].Icon);
        }

        float[] xPositions = _layout.CalculatePositions(bounds);

        for (int i = 0; i < traits.Count; i++)
        {
            traitTransforms[i].position = new Vector3(xPositions[i], transform.position.y, transform.position.z);
        }
    }

    private void RemoveExistingTraits()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
