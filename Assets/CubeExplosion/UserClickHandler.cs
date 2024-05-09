using UnityEngine;

namespace CubeExplosion
{
    public class UserClickHandler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void Update()
        {
            bool isLeftMouseButtonPressed = Input.GetMouseButtonDown(button: 0);

            if (isLeftMouseButtonPressed == true)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    if (raycastHit.collider.TryGetComponent(out Cube cube))
                    {
                        cube.Explode();
                    }
                }
            }
        }
    }
}
