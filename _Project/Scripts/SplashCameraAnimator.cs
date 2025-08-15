using UnityEngine;

public class SplashCameraAnimator : MonoBehaviour
{
    [System.Serializable]
    public class CameraKeyframe
    {
        public float time;
        public Vector3 position;
        public float fov;
    }

    public CameraKeyframe[] keyframes;
    public float animationDuration = 4.5f;

    private Camera _camera;
    private float _startTime;
    private bool _animationComplete = false;

    void Start()
    {
        _camera = GetComponent<Camera>();
        if (_camera == null)
        {
            Debug.LogError("SplashCameraAnimator requires a Camera component on the same GameObject.");
            enabled = false;
            return;
        }

        if (keyframes == null || keyframes.Length == 0)
        {
            Debug.LogWarning("SplashCameraAnimator: Keyframes not set in inspector. Using default values from GDD.");
            keyframes = new CameraKeyframe[4];
            keyframes[0] = new CameraKeyframe { time = 0.0f, position = new Vector3(0f, 0.2f, 2.2f), fov = 65f };
            keyframes[1] = new CameraKeyframe { time = 1.6f, position = new Vector3(0.12f, 0.12f, 1.35f), fov = 55f };
            keyframes[2] = new CameraKeyframe { time = 3.2f, position = new Vector3(0f, 0.0f, 0.9f), fov = 45f };
            keyframes[3] = new CameraKeyframe { time = 4.5f, position = new Vector3(0f, 0.0f, 1.2f), fov = 50f };
        }
        else if (keyframes.Length != 4)
        {
            Debug.LogError("This script requires exactly 4 keyframes to define the cubic Bezier curve.");
            enabled = false;
            return;
        }

        _startTime = Time.time;
    }

    void Update()
    {
        if (_animationComplete) return;

        float elapsedTime = Time.time - _startTime;
        float t = elapsedTime / animationDuration;

        if (t >= 1f)
        {
            t = 1f;
            _animationComplete = true;
        }

        // Interpolate position
        Vector3 newPosition = GetPointOnBezierCurve(
            keyframes[0].position,
            keyframes[1].position,
            keyframes[2].position,
            keyframes[3].position,
            t
        );
        _camera.transform.position = newPosition;

        // Interpolate FOV
        float newFov = GetPointOnBezierCurve(
            keyframes[0].fov,
            keyframes[1].fov,
            keyframes[2].fov,
            keyframes[3].fov,
            t
        );
        _camera.fieldOfView = newFov;

        if (_animationComplete)
        {
            Debug.Log("Splash screen animation complete.");
            // Optionally, you could disable this component now
            // enabled = false;
        }
    }

    /// <summary>
    /// Calculates a point on a cubic Bezier curve defined by four points.
    /// </summary>
    /// <param name="p0">Start point of the curve.</param>
    /// <param name="p1">First control point.</param>
    /// <param name="p2">Second control point.</param>
    /// <param name="p3">End point of the curve.</param>
    /// <param name="t">The normalized time (0 to 1) to evaluate the curve at.</param>
    /// <returns>The point on the curve at the given time t.</returns>
    public static Vector3 GetPointOnBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * oneMinusT * p0 +
               3f * oneMinusT * oneMinusT * t * p1 +
               3f * oneMinusT * t * t * p2 +
               t * t * t * p3;
    }

    /// <summary>
    /// Calculates a value on a cubic Bezier curve defined by four values.
    /// </summary>
    /// <param name="v0">Start value.</param>
    /// <param name="v1">First control value.</param>
    /// <param name="v2">Second control value.</param>
    /// <param name="v3">End value.</param>
    /// <param name="t">The normalized time (0 to 1) to evaluate the curve at.</param>
    /// <returns>The interpolated value on the curve at the given time t.</returns>
    public static float GetPointOnBezierCurve(float v0, float v1, float v2, float v3, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * oneMinusT * v0 +
               3f * oneMinusT * oneMinusT * t * v1 +
               3f * oneMinusT * t * t * v2 +
               t * t * t * v3;
    }
}
