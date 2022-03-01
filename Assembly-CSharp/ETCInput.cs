using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200495F RID: 18783
public class ETCInput : MonoBehaviour
{
	// Token: 0x170022C3 RID: 8899
	// (get) Token: 0x0601AFB9 RID: 110521 RVA: 0x0084D4C0 File Offset: 0x0084B8C0
	public static ETCInput instance
	{
		get
		{
			if (!ETCInput._instance)
			{
				ETCInput._instance = (Object.FindObjectOfType(typeof(ETCInput)) as ETCInput);
				if (!ETCInput._instance)
				{
					GameObject gameObject = new GameObject("InputManager");
					ETCInput._instance = gameObject.AddComponent<ETCInput>();
				}
			}
			return ETCInput._instance;
		}
	}

	// Token: 0x0601AFBA RID: 110522 RVA: 0x0084D520 File Offset: 0x0084B920
	public void RegisterControl(ETCBase ctrl)
	{
		if (!this.controls.ContainsKey(ctrl.name))
		{
			this.controls.Add(ctrl.name, ctrl);
			if (ctrl.GetType() == typeof(ETCJoystick))
			{
				this.RegisterAxis((ctrl as ETCJoystick).axisX);
				this.RegisterAxis((ctrl as ETCJoystick).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCTouchPad))
			{
				this.RegisterAxis((ctrl as ETCTouchPad).axisX);
				this.RegisterAxis((ctrl as ETCTouchPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCDPad))
			{
				this.RegisterAxis((ctrl as ETCDPad).axisX);
				this.RegisterAxis((ctrl as ETCDPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCButton))
			{
				this.RegisterAxis((ctrl as ETCButton).axis);
			}
		}
	}

	// Token: 0x0601AFBB RID: 110523 RVA: 0x0084D634 File Offset: 0x0084BA34
	public void UnRegisterControl(ETCBase ctrl)
	{
		if (this.controls.ContainsKey(ctrl.name) && ctrl.enabled)
		{
			this.controls.Remove(ctrl.name);
			if (ctrl.GetType() == typeof(ETCJoystick))
			{
				this.UnRegisterAxis((ctrl as ETCJoystick).axisX);
				this.UnRegisterAxis((ctrl as ETCJoystick).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCTouchPad))
			{
				this.UnRegisterAxis((ctrl as ETCTouchPad).axisX);
				this.UnRegisterAxis((ctrl as ETCTouchPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCDPad))
			{
				this.UnRegisterAxis((ctrl as ETCDPad).axisX);
				this.UnRegisterAxis((ctrl as ETCDPad).axisY);
			}
			else if (ctrl.GetType() == typeof(ETCButton))
			{
				this.UnRegisterAxis((ctrl as ETCButton).axis);
			}
		}
	}

	// Token: 0x0601AFBC RID: 110524 RVA: 0x0084D74E File Offset: 0x0084BB4E
	public void Create()
	{
	}

	// Token: 0x0601AFBD RID: 110525 RVA: 0x0084D750 File Offset: 0x0084BB50
	public static void Register(ETCBase ctrl)
	{
		ETCInput.instance.RegisterControl(ctrl);
	}

	// Token: 0x0601AFBE RID: 110526 RVA: 0x0084D75D File Offset: 0x0084BB5D
	public static void UnRegister(ETCBase ctrl)
	{
		ETCInput.instance.UnRegisterControl(ctrl);
	}

	// Token: 0x0601AFBF RID: 110527 RVA: 0x0084D76C File Offset: 0x0084BB6C
	public static void SetControlVisible(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.visible = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x0601AFC0 RID: 110528 RVA: 0x0084D7B8 File Offset: 0x0084BBB8
	public static bool GetControlVisible(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.visible;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFC1 RID: 110529 RVA: 0x0084D7F8 File Offset: 0x0084BBF8
	public static void SetControlActivated(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.activated = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x0601AFC2 RID: 110530 RVA: 0x0084D844 File Offset: 0x0084BC44
	public static bool GetControlActivated(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.activated;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFC3 RID: 110531 RVA: 0x0084D884 File Offset: 0x0084BC84
	public static void SetControlSwipeIn(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.isSwipeIn = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x0601AFC4 RID: 110532 RVA: 0x0084D8D0 File Offset: 0x0084BCD0
	public static bool GetControlSwipeIn(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.isSwipeIn;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFC5 RID: 110533 RVA: 0x0084D910 File Offset: 0x0084BD10
	public static void SetControlSwipeOut(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.isSwipeOut = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x0601AFC6 RID: 110534 RVA: 0x0084D95C File Offset: 0x0084BD5C
	public static bool GetControlSwipeOut(string ctrlName, bool value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.isSwipeOut;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFC7 RID: 110535 RVA: 0x0084D99C File Offset: 0x0084BD9C
	public static void SetDPadAxesCount(string ctrlName, ETCBase.DPadAxis value)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			ETCInput.control.dPadAxisCount = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		}
	}

	// Token: 0x0601AFC8 RID: 110536 RVA: 0x0084D9E8 File Offset: 0x0084BDE8
	public static ETCBase.DPadAxis GetDPadAxesCount(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			return ETCInput.control.dPadAxisCount;
		}
		Debug.LogWarning("ETCInput : " + ctrlName + " doesn't exist");
		return ETCBase.DPadAxis.Two_Axis;
	}

	// Token: 0x0601AFC9 RID: 110537 RVA: 0x0084DA28 File Offset: 0x0084BE28
	public static ETCJoystick GetControlJoystick(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			return (ETCJoystick)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0601AFCA RID: 110538 RVA: 0x0084DA78 File Offset: 0x0084BE78
	public static ETCDPad GetControlDPad(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCDPad))
		{
			return (ETCDPad)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0601AFCB RID: 110539 RVA: 0x0084DAC8 File Offset: 0x0084BEC8
	public static ETCTouchPad GetControlTouchPad(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCTouchPad))
		{
			return (ETCTouchPad)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0601AFCC RID: 110540 RVA: 0x0084DB18 File Offset: 0x0084BF18
	public static ETCButton GetControlButton(string ctrlName)
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			return (ETCButton)ETCInput.control;
		}
		return null;
	}

	// Token: 0x0601AFCD RID: 110541 RVA: 0x0084DB68 File Offset: 0x0084BF68
	public static void SetControlSprite(string ctrlName, Sprite spr, Color color = default(Color))
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control))
		{
			Image component = ETCInput.control.GetComponent<Image>();
			if (component)
			{
				component.sprite = spr;
				component.color = color;
			}
		}
	}

	// Token: 0x0601AFCE RID: 110542 RVA: 0x0084DBB4 File Offset: 0x0084BFB4
	public static void SetJoystickThumbSprite(string ctrlName, Sprite spr, Color color = default(Color))
	{
		if (ETCInput.instance.controls.TryGetValue(ctrlName, out ETCInput.control) && ETCInput.control.GetType() == typeof(ETCJoystick))
		{
			ETCJoystick etcjoystick = (ETCJoystick)ETCInput.control;
			if (etcjoystick)
			{
				Image component = etcjoystick.thumb.GetComponent<Image>();
				if (component)
				{
					component.sprite = spr;
					component.color = color;
				}
			}
		}
	}

	// Token: 0x0601AFCF RID: 110543 RVA: 0x0084DC2F File Offset: 0x0084C02F
	public static void SetButtonPressedSprite(string ctrlName, Sprite spr, Color color = default(Color))
	{
	}

	// Token: 0x0601AFD0 RID: 110544 RVA: 0x0084DC34 File Offset: 0x0084C034
	public static void SetAxisSpeed(string axisName, float speed)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.speed = speed;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD1 RID: 110545 RVA: 0x0084DC80 File Offset: 0x0084C080
	public static void SetAxisGravity(string axisName, float gravity)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.gravity = gravity;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD2 RID: 110546 RVA: 0x0084DCCC File Offset: 0x0084C0CC
	public static void SetTurnMoveSpeed(string ctrlName, float speed)
	{
		ETCJoystick controlJoystick = ETCInput.GetControlJoystick(ctrlName);
		if (controlJoystick)
		{
			controlJoystick.tmSpeed = speed;
		}
	}

	// Token: 0x0601AFD3 RID: 110547 RVA: 0x0084DCF4 File Offset: 0x0084C0F4
	public static void ResetAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisValue = 0f;
			ETCInput.axis.axisSpeedValue = 0f;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD4 RID: 110548 RVA: 0x0084DD54 File Offset: 0x0084C154
	public static void SetAxisEnabled(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.enable = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD5 RID: 110549 RVA: 0x0084DDA0 File Offset: 0x0084C1A0
	public static bool GetAxisEnabled(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.enable;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFD6 RID: 110550 RVA: 0x0084DDE0 File Offset: 0x0084C1E0
	public static void SetAxisInverted(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.invertedAxis = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD7 RID: 110551 RVA: 0x0084DE2C File Offset: 0x0084C22C
	public static bool GetAxisInverted(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.invertedAxis;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFD8 RID: 110552 RVA: 0x0084DE6C File Offset: 0x0084C26C
	public static void SetAxisDeadValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.deadValue = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFD9 RID: 110553 RVA: 0x0084DEB8 File Offset: 0x0084C2B8
	public static float GetAxisDeadValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.deadValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFDA RID: 110554 RVA: 0x0084DF04 File Offset: 0x0084C304
	public static void SetAxisSensitivity(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.speed = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFDB RID: 110555 RVA: 0x0084DF50 File Offset: 0x0084C350
	public static float GetAxisSensitivity(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.speed;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFDC RID: 110556 RVA: 0x0084DF9C File Offset: 0x0084C39C
	public static void SetAxisThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFDD RID: 110557 RVA: 0x0084DFE8 File Offset: 0x0084C3E8
	public static float GetAxisThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFDE RID: 110558 RVA: 0x0084E034 File Offset: 0x0084C434
	public static void SetAxisInertia(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isEnertia = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFDF RID: 110559 RVA: 0x0084E080 File Offset: 0x0084C480
	public static bool GetAxisInertia(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isEnertia;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFE0 RID: 110560 RVA: 0x0084E0C0 File Offset: 0x0084C4C0
	public static void SetAxisInertiaSpeed(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.inertia = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFE1 RID: 110561 RVA: 0x0084E10C File Offset: 0x0084C50C
	public static float GetAxisInertiaSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.inertia;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFE2 RID: 110562 RVA: 0x0084E158 File Offset: 0x0084C558
	public static void SetAxisInertiaThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.inertiaThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFE3 RID: 110563 RVA: 0x0084E1A4 File Offset: 0x0084C5A4
	public static float GetAxisInertiaThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.inertiaThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFE4 RID: 110564 RVA: 0x0084E1F0 File Offset: 0x0084C5F0
	public static void SetAxisAutoStabilization(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isAutoStab = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFE5 RID: 110565 RVA: 0x0084E23C File Offset: 0x0084C63C
	public static bool GetAxisAutoStabilization(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isAutoStab;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFE6 RID: 110566 RVA: 0x0084E27C File Offset: 0x0084C67C
	public static void SetAxisAutoStabilizationSpeed(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.autoStabSpeed = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFE7 RID: 110567 RVA: 0x0084E2C8 File Offset: 0x0084C6C8
	public static float GetAxisAutoStabilizationSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.autoStabSpeed;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFE8 RID: 110568 RVA: 0x0084E314 File Offset: 0x0084C714
	public static void SetAxisAutoStabilizationThreshold(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.autoStabThreshold = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFE9 RID: 110569 RVA: 0x0084E360 File Offset: 0x0084C760
	public static float GetAxisAutoStabilizationThreshold(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.autoStabThreshold;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFEA RID: 110570 RVA: 0x0084E3AC File Offset: 0x0084C7AC
	public static void SetAxisClampRotation(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isClampRotation = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFEB RID: 110571 RVA: 0x0084E3F8 File Offset: 0x0084C7F8
	public static bool GetAxisClampRotation(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isClampRotation;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFEC RID: 110572 RVA: 0x0084E438 File Offset: 0x0084C838
	public static void SetAxisClampRotationValue(string axisName, float min, float max)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.minAngle = min;
			ETCInput.axis.maxAngle = max;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFED RID: 110573 RVA: 0x0084E490 File Offset: 0x0084C890
	public static void SetAxisClampRotationMinValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.minAngle = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFEE RID: 110574 RVA: 0x0084E4DC File Offset: 0x0084C8DC
	public static void SetAxisClampRotationMaxValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.maxAngle = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFEF RID: 110575 RVA: 0x0084E528 File Offset: 0x0084C928
	public static float GetAxisClampRotationMinValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.minAngle;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFF0 RID: 110576 RVA: 0x0084E574 File Offset: 0x0084C974
	public static float GetAxisClampRotationMaxValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.maxAngle;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFF1 RID: 110577 RVA: 0x0084E5C0 File Offset: 0x0084C9C0
	public static void SetAxisDirecTransform(string axisName, Transform value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.directTransform = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFF2 RID: 110578 RVA: 0x0084E60C File Offset: 0x0084CA0C
	public static Transform GetAxisDirectTransform(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.directTransform;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return null;
	}

	// Token: 0x0601AFF3 RID: 110579 RVA: 0x0084E64C File Offset: 0x0084CA4C
	public static void SetAxisDirectAction(string axisName, ETCAxis.DirectAction value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.directAction = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFF4 RID: 110580 RVA: 0x0084E698 File Offset: 0x0084CA98
	public static ETCAxis.DirectAction GetAxisDirectAction(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.directAction;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return ETCAxis.DirectAction.Rotate;
	}

	// Token: 0x0601AFF5 RID: 110581 RVA: 0x0084E6D8 File Offset: 0x0084CAD8
	public static void SetAxisAffectedAxis(string axisName, ETCAxis.AxisInfluenced value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.axisInfluenced = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFF6 RID: 110582 RVA: 0x0084E724 File Offset: 0x0084CB24
	public static ETCAxis.AxisInfluenced GetAxisAffectedAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisInfluenced;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return ETCAxis.AxisInfluenced.X;
	}

	// Token: 0x0601AFF7 RID: 110583 RVA: 0x0084E764 File Offset: 0x0084CB64
	public static void SetAxisOverTime(string axisName, bool value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.isValueOverTime = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFF8 RID: 110584 RVA: 0x0084E7B0 File Offset: 0x0084CBB0
	public static bool GetAxisOverTime(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.isValueOverTime;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601AFF9 RID: 110585 RVA: 0x0084E7F0 File Offset: 0x0084CBF0
	public static void SetAxisOverTimeStep(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.overTimeStep = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFFA RID: 110586 RVA: 0x0084E83C File Offset: 0x0084CC3C
	public static float GetAxisOverTimeStep(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.overTimeStep;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFFB RID: 110587 RVA: 0x0084E888 File Offset: 0x0084CC88
	public static void SetAxisOverTimeMaxValue(string axisName, float value)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			ETCInput.axis.maxOverTimeValue = value;
		}
		else
		{
			Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		}
	}

	// Token: 0x0601AFFC RID: 110588 RVA: 0x0084E8D4 File Offset: 0x0084CCD4
	public static float GetAxisOverTimeMaxValue(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.maxOverTimeValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601AFFD RID: 110589 RVA: 0x0084E920 File Offset: 0x0084CD20
	public static float GetAxis(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisValue;
		}
		Debug.LogWarning("ETCInput : " + axisName + " doesn't exist");
		return 0f;
	}

	// Token: 0x0601AFFE RID: 110590 RVA: 0x0084E96C File Offset: 0x0084CD6C
	public static float GetAxisSpeed(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisSpeedValue;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return 0f;
	}

	// Token: 0x0601AFFF RID: 110591 RVA: 0x0084E9A8 File Offset: 0x0084CDA8
	public static bool GetAxisDownUp(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownUp;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B000 RID: 110592 RVA: 0x0084E9F4 File Offset: 0x0084CDF4
	public static bool GetAxisDownDown(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownDown;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B001 RID: 110593 RVA: 0x0084EA40 File Offset: 0x0084CE40
	public static bool GetAxisDownRight(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownRight;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B002 RID: 110594 RVA: 0x0084EA8C File Offset: 0x0084CE8C
	public static bool GetAxisDownLeft(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.DownLeft;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B003 RID: 110595 RVA: 0x0084EAD8 File Offset: 0x0084CED8
	public static bool GetAxisPressedUp(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressUp;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B004 RID: 110596 RVA: 0x0084EB24 File Offset: 0x0084CF24
	public static bool GetAxisPressedDown(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressDown;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B005 RID: 110597 RVA: 0x0084EB74 File Offset: 0x0084CF74
	public static bool GetAxisPressedRight(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressRight;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B006 RID: 110598 RVA: 0x0084EBC4 File Offset: 0x0084CFC4
	public static bool GetAxisPressedLeft(string axisName)
	{
		if (ETCInput.instance.axes.TryGetValue(axisName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.PressLeft;
		}
		Debug.LogWarning(axisName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B007 RID: 110599 RVA: 0x0084EC14 File Offset: 0x0084D014
	public static bool GetButtonDown(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Down;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B008 RID: 110600 RVA: 0x0084EC60 File Offset: 0x0084D060
	public static bool GetButton(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Down || ETCInput.axis.axisState == ETCAxis.AxisState.Press;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B009 RID: 110601 RVA: 0x0084ECBC File Offset: 0x0084D0BC
	public static bool GetButtonUp(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisState == ETCAxis.AxisState.Up;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return false;
	}

	// Token: 0x0601B00A RID: 110602 RVA: 0x0084ED08 File Offset: 0x0084D108
	public static float GetButtonValue(string buttonName)
	{
		if (ETCInput.instance.axes.TryGetValue(buttonName, out ETCInput.axis))
		{
			return ETCInput.axis.axisValue;
		}
		Debug.LogWarning(buttonName + " doesn't exist");
		return -1f;
	}

	// Token: 0x0601B00B RID: 110603 RVA: 0x0084ED44 File Offset: 0x0084D144
	private void RegisterAxis(ETCAxis axis)
	{
		if (ETCInput.instance.axes.ContainsKey(axis.name))
		{
			Debug.LogWarning("ETCInput axis : " + axis.name + " already exists");
		}
		else
		{
			this.axes.Add(axis.name, axis);
		}
	}

	// Token: 0x0601B00C RID: 110604 RVA: 0x0084ED9C File Offset: 0x0084D19C
	private void UnRegisterAxis(ETCAxis axis)
	{
		if (ETCInput.instance.axes.ContainsKey(axis.name))
		{
			this.axes.Remove(axis.name);
		}
	}

	// Token: 0x04012D2F RID: 77103
	public static ETCInput _instance;

	// Token: 0x04012D30 RID: 77104
	private Dictionary<string, ETCAxis> axes = new Dictionary<string, ETCAxis>();

	// Token: 0x04012D31 RID: 77105
	private Dictionary<string, ETCBase> controls = new Dictionary<string, ETCBase>();

	// Token: 0x04012D32 RID: 77106
	private static ETCBase control;

	// Token: 0x04012D33 RID: 77107
	private static ETCAxis axis;
}
