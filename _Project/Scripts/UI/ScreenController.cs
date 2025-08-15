using UnityEngine;
using System.Collections;

/// <summary>
/// An abstract base class for all UI screens.
/// Handles common functionality like showing, hiding, and fade transitions.
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public abstract class ScreenController : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 0.25f;

    protected CanvasGroup _canvasGroup;
    protected Coroutine _fadeCoroutine;

    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        if (ScreenManager.Instance != null)
        {
            ScreenManager.Instance.RegisterScreen(this);
        }
        else
        {
            Debug.LogError("ScreenManager instance not found. Make sure a ScreenManager prefab or instance exists in your scene.");
        }
    }

    /// <summary>
    /// Shows the screen with a fade-in transition.
    /// </summary>
    public virtual void Show()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(Fade(1f));
        OnShown();
    }

    /// <summary>
    /// Hides the screen with a fade-out transition.
    /// </summary>
    public virtual void Hide()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }
        _fadeCoroutine = StartCoroutine(Fade(0f));
        OnHidden();
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = _canvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        _canvasGroup.alpha = targetAlpha;
        _canvasGroup.interactable = (targetAlpha == 1f);
        _canvasGroup.blocksRaycasts = (targetAlpha == 1f);
        _fadeCoroutine = null;
    }

    /// <summary>
    /// Called when the screen has finished its show transition.
    /// </summary>
    protected virtual void OnShown() { }

    /// <summary>
    /// Called when the screen has finished its hide transition.
    /// </summary>
    protected virtual void OnHidden() { }
}
