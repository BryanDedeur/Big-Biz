using UnityEngine;


public class CreateUICollider : MonoBehaviour
{

    private void OnEnable()
    {
        ValidateCollider();
    }

    private void OnValidate()
    {
        ValidateCollider();
    }

    private void Start()
    {
        ValidateCollider();
    }

    private void ValidateCollider()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();

        if (boxCollider == null)
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();
        }

        //boxCollider.size = rectTransform.sizeDelta;
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        if (width < 0)
        {
            width = 0;
        }
        if(height < 0)
        {
            height = 0;
        }
        boxCollider.size = new Vector3(width, height, 0);
        boxCollider.center = rectTransform.rect.center;
    }
}