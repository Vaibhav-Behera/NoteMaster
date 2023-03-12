using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputFieldCreator : MonoBehaviour
{
    public InputField inputFieldPrefab;
    public Transform inputFieldParent;

    public int inputcreated = 0;
    public Text inputcreatedtext;

    private void Start()
    {
        // Disable raycasting for the input field parent to allow clicking through to other objects
        inputFieldParent.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void CreateInputField()
    {
        InputField newInputField = Instantiate(inputFieldPrefab, inputFieldParent);
        newInputField.transform.SetAsLastSibling();

        // Add the InputFieldMover script to the new InputField object
        newInputField.gameObject.AddComponent<InputFieldMover>();

        inputcreated++;
        inputcreatedtext.text = inputcreated.ToString();
    }

    private class InputFieldMover : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        private RectTransform rectTransform;
        private Canvas canvas;

        private void Start()
        {
            // Get the RectTransform and Canvas components
            rectTransform = GetComponent<RectTransform>();
            canvas = GetComponentInParent<Canvas>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Set the InputField as the topmost element
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Move the InputField based on the cursor position
            Vector2 cursorPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out cursorPosition);
            rectTransform.anchoredPosition = cursorPosition;
        }
    }
}

