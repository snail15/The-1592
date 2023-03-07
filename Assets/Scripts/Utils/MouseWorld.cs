using System;
using UnityEngine;

namespace Utils 
{
    public class MouseWorld : Singleton<MouseWorld> {
        
        public event EventHandler<UnitInfoEventArgs> OnMouseOverUnit; 
        public event EventHandler<UnitInfoEventArgs> OnMouseOutUnit; 
        
        [SerializeField] private LayerMask unitLayerMask;
        private Camera _camera;

        public class UnitInfoEventArgs 
        {
            public Unit Unit;
            public UnitInfo UnitInfo;
        }
        
        protected override void Awake()
        {
            base.Awake();
            _camera = Camera.main;
        }
        private void Update()
        {
            if (MouseOverUnit(out UnitInfo unitInfo, out Unit unit))
            {
                OnMouseOverUnit?.Invoke(this, new UnitInfoEventArgs{Unit = unit, UnitInfo = unitInfo});
            }
            else
            {
                OnMouseOutUnit?.Invoke(this, null);
            }
            
        }
        private bool MouseOverUnit(out UnitInfo unitInfo, out Unit unit)
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            var ray = new Ray2D(mousePos2D, transform.TransformDirection(Vector2.positiveInfinity));
            
            unitInfo = GetByRay<UnitInfo>(ray);
            
            unit = GetByRay<Unit>(ray);
            
            return unitInfo != null && unit != null;

        }
        
        private T GetByRay<T>(Ray2D ray) where T : class
        {
            //RaycastHit hit;
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            var mousePos2D = new Vector2(mousePosition.x, mousePosition.y);
            var hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, unitLayerMask);
            // if (Physics.Raycast(ray, out hit, float.PositiveInfinity, layerMask))
            if (hit) return hit.transform.GetComponentInParent<T>();
            return null;
        }
        
    }
}
