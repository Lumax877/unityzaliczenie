using UnityEngine;
using UnityEngine.UI;

public class DynamicTextCreation : MonoBehaviour
{
    public Font customFont; 

    void Start()
    {
        
        GameObject textObject = new GameObject("DynamicTextObject");
        Text textComponent = textObject.AddComponent<Text>();

        textComponent.text = "Hello, World!";
        
        textComponent.fontSize = 24;
        textComponent.font = customFont;

        textComponent.color = Color.red;

        textObject.transform.SetParent(null);
    }
}
