using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;  
using UnityEngine.EventSystems;  

// （1）Input.touchPressureSupported：是否支持3Dtouch，bool类型 
// （2）Touch.pressure：获取当前按压值，float类型 
// （3）Touch.maximumPossiblePressure：获取最大按压值，float类型

public class ThreeDTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler{

	public Button threeDTouchBtn;
	public Image scaleImage; 
	public Text showText;
	public Text pressText;
	// Use this for initialization
	void Start () {
		if(Input.touchPressureSupported)
		{
			showText.text = "支持3DTouch";
			
		}
		else
		{
			showText.text = "！！不支持3DTouch！！";

		}
	}
  
    [SerializeField]  
    UnityEvent m_OnLongpress = new UnityEvent();  
    private bool isHad3DTouch = false;  
    private float lastInvokeTime;  
  
  
    // Update is called once per frame  
    void Update()  
    {  
		if(Input.touchPressureSupported == false)
		{
			return;
		}

		scaleImage.transform.localScale = new Vector3(Input.GetTouch (0).pressure,Input.GetTouch (0).pressure,Input.GetTouch (0).pressure);
        pressText.text = "力度："+Input.GetTouch (0).pressure.ToString();
		if (isHad3DTouch == false)  
        { 
			
			if(Input.GetTouch (0).pressure > Input.GetTouch(0).maximumPossiblePressure*0.7f)
			{
				isHad3DTouch = true;
				Handheld.Vibrate();
			}
        }  
    }  
  
  
    public void OnPointerDown(PointerEventData eventData)  
    {  
        m_OnLongpress.Invoke();  
  
  
        isHad3DTouch = false;  
  
  
        lastInvokeTime = Time.time;  
        Debug.Log("鼠标按下");  
    }  
  
  
    public void OnPointerUp(PointerEventData eventData)  
    {  
        isHad3DTouch = true;  
        Debug.Log("鼠标抬起");  
    }  
  
  
    public void OnPointerExit(PointerEventData eventData)  
    {  
        Debug.Log("鼠标退出");  
    }  
    public void OnPointerClick(PointerEventData eventData)  
    {  
        Debug.Log("鼠标点击");  
    }  

}
