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

        Transform[] traitTransforms = new Transform[traits.Count];

        for (int i = 0; i < traits.Count; i++)
        {
            GameObject traitObj = Instantiate(_traitTemplate, transform.position, quaternion.identity, transform);
            traitTransforms[i] = traitObj.transform;
            TraitIcon traitIcon = traitObj.GetComponent<TraitIcon>();
            traitIcon.SetTrait(traits[i]);
        }

        _layout.Reposition(traitTransforms);
    }

    private void RemoveExistingTraits()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
