using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSelection : MonoBehaviour
{

    [SerializeField] private string selectableTag = "Enemy";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material enemyMaterial;

    private Transform _selection;

    // Update is called once per frame
    void Update()
    {

        if (_selection != null)
        {
            var selectionRender = _selection.GetComponent<Renderer>();
            selectionRender.material = enemyMaterial;
            _selection = null;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {


            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        selectionRender.material = highlightMaterial;
                    }
                    _selection = selection;
                }

            }
        }
    }
}
