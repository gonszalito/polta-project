using UnityEngine.UI;
using UnityEngine;

public class ScrollViewSystem : MonoBehaviour
{
    private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollMove();
    }

    void ScrollMove()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            scrollRect.horizontalNormalizedPosition -= scrollSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            scrollRect.horizontalNormalizedPosition += scrollSpeed;
        }
    }
}
