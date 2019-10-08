using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GraphicRaycaster))]
public class ImageSelector : MonoBehaviour
{
    public string catagoryTitleName;
    public Text catagoryTitle;
    public Image fullImage;
    public Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        catagoryTitle.text = catagoryTitleName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPointerDown();
        }
    }
    public void OnPointerDown()
    {
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        PointerEventData data = new PointerEventData(null);
        data.position = Input.mousePosition;
        
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(data, results);
        if  (results.Count > 0)
        {
            //we hit someting
            OnPreviewClick(results[0].gameObject);
        }
        void OnPreviewClick(GameObject thisButton)
        {
            //set the mew image based on what they clicked on
            Image previewImage = thisButton.GetComponent<Image>();
            {
                if (previewImage != null)
                {
                    fullImage.sprite = previewImage.sprite;
                    fullImage.type = Image.Type.Simple;
                    fullImage.preserveAspect = true;
                }
            }
        }
    }
    public void OnPointerEnter(Image image)
    {
        // when the users gaze points to an image, highlight the game object
        image.material = highlightMaterial;
        Debug.Log("Called OnPointerEnter");
    }
    public void OnPointerExit(Image image)
    {
        image.material = null;
    }
}

