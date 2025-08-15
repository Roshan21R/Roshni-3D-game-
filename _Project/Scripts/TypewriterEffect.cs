using UnityEngine;
using System.Collections;
using TMPro;

/// <summary>
/// A reusable component to reveal a TextMeshProUGUI component's text
/// one character at a time, creating a typewriter effect.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float charactersPerSecond = 20f;
    [SerializeField] private bool playOnStart = false;

    private TextMeshProUGUI _textMeshPro;
    private Coroutine _typingCoroutine;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (playOnStart)
        {
            // We'll use the existing text on the component if playOnStart is true
            StartTyping(_textMeshPro.text);
        }
    }

    public void StartTyping(string text)
    {
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
        }
        _typingCoroutine = StartCoroutine(TypeTextRoutine(text));
    }

    private IEnumerator TypeTextRoutine(string text)
    {
        _textMeshPro.text = text;
        _textMeshPro.maxVisibleCharacters = 0;
        _textMeshPro.ForceMeshUpdate(); // Ensures the text container is sized correctly before we start.

        yield return null; // Wait one frame for the mesh update to complete.

        int visibleCount = 0;
        int totalLength = text.Length;
        float delay = 1f / charactersPerSecond;

        while (visibleCount < totalLength)
        {
            visibleCount++;
            _textMeshPro.maxVisibleCharacters = visibleCount;
            yield return new WaitForSeconds(delay);
        }

        _typingCoroutine = null;
    }
}
