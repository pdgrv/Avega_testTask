using UnityEngine;

namespace Avega.Others
{
    public static class CameraExtension
    {
        public static bool IsPointInSight(this Camera camera, Vector3 point, LayerMask layer)
        {
            if (Physics.Linecast(camera.transform.position, point, layer))
                return false;

            Vector3 viewportPoint = camera.WorldToViewportPoint(point);

            return viewportPoint.z > 0;
        }
    }
}