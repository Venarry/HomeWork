using UnityEngine;

namespace CubeExplosion
{
    public class UserClickHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.TryGetComponent(out CubeView cube))
                    {
                        cube.Explode();
                    }
                }
            }
        }
    }
}
