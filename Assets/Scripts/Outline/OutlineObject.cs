using System;
using UnityEngine;

namespace Outline
{
    public class OutlineObject : MonoBehaviour
    {
        [SerializeField] private Material outlineMaterial;
        [SerializeField] private float outlineScale;
        [SerializeField] private Color outlineColor;
        
        private Renderer _renderer;
        private static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");
        private static readonly int Scale = Shader.PropertyToID("_Scale");

        public void EnableOutline()
        {
            if (!_renderer)
            {
                _renderer = CreateOutline(outlineMaterial, outlineScale, outlineColor);
            }
            
            Debug.Log("Interact");
            _renderer.enabled = true;
        }

        public void DisableOutline()
        {
            if (!_renderer) return;
            
            _renderer.enabled = false;
        }

        private Renderer CreateOutline(Material outLineMaterial, float scale, Color color)
        {
            GameObject outlineObj = Instantiate(gameObject, transform.position, transform.rotation,transform);
            Renderer rend = outlineObj.GetComponent<Renderer>();
            
            rend.material = outLineMaterial;
            rend.material.SetColor(OutlineColor, color);
            rend.material.SetFloat(Scale, scale);
            rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            outlineObj.GetComponent<OutlineObject>().enabled = false;

            rend.enabled = false;
            
            return rend;
        }
    }
}
