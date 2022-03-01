using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F0F RID: 3855
public class ComScaleScripts : MonoBehaviour
{
	// Token: 0x06009684 RID: 38532 RVA: 0x001C9A4C File Offset: 0x001C7E4C
	public void Scale(float s)
	{
		Vector3 localScale = this.mRect.localScale;
		this.mRect.localScale = Vector3.one * s;
		ETCJoystick component = base.GetComponent<ETCJoystick>();
		if (component != null)
		{
			Image component2 = component.thumb.GetComponent<Image>();
			if (component2 != null)
			{
				component2.transform.localScale = Vector3.one / s;
			}
		}
	}

	// Token: 0x06009685 RID: 38533 RVA: 0x001C9ABC File Offset: 0x001C7EBC
	public void SetAlpha(float alpha)
	{
		ETCJoystick component = base.GetComponent<ETCJoystick>();
		if (component != null)
		{
			Image component2 = component.GetComponent<Image>();
			if (component2 != null)
			{
				component2.CrossFadeAlpha(alpha, 0.1f, true);
			}
		}
	}

	// Token: 0x06009686 RID: 38534 RVA: 0x001C9AFC File Offset: 0x001C7EFC
	public void SetThumbAlpha(float alpha)
	{
		ETCJoystick component = base.GetComponent<ETCJoystick>();
		if (component != null)
		{
			Image component2 = component.thumb.GetComponent<Image>();
			if (component2 != null)
			{
				component2.CrossFadeAlpha(alpha, 0.1f, true);
			}
		}
	}

	// Token: 0x06009687 RID: 38535 RVA: 0x001C9B44 File Offset: 0x001C7F44
	public void SetDirActive(bool active)
	{
		ETCJoystick component = base.GetComponent<ETCJoystick>();
		if (component != null && component.dirObj != null)
		{
			component.dirObj.CustomActive(active);
		}
	}

	// Token: 0x04004D5E RID: 19806
	public RectTransform mRect;
}
