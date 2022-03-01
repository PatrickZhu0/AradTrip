using System;
using UnityEngine;

// Token: 0x02000F83 RID: 3971
[ExecuteInEditMode]
public class ETCButtonModeSlider : MonoBehaviour
{
	// Token: 0x06009980 RID: 39296 RVA: 0x001D8C41 File Offset: 0x001D7041
	private void Start()
	{
	}

	// Token: 0x06009981 RID: 39297 RVA: 0x001D8C44 File Offset: 0x001D7044
	private void UpdateButtonPosition()
	{
		if (this.buttonList == null)
		{
			return;
		}
		int num = this.buttonList.Length;
		for (int i = 0; i < num; i++)
		{
			ETCButton etcbutton = this.buttonList[i];
			etcbutton.anchor = ETCBase.RectAnchor.BottonRight;
			float num2 = Mathf.Cos(1.5707964f / (float)(num - 1) * (float)i) * this.radius;
			float num3 = Mathf.Sin(1.5707964f / (float)(num - 1) * (float)i) * this.radius;
			etcbutton.anchorOffet = new Vector2(num3, num2) + this.offset;
			etcbutton.isSwipeOut = true;
		}
		this.centerButton.anchorOffet = this.offset;
	}

	// Token: 0x06009982 RID: 39298 RVA: 0x001D8CEE File Offset: 0x001D70EE
	private void Update()
	{
		this.UpdateButtonPosition();
	}

	// Token: 0x04004F0F RID: 20239
	public float radius = 300f;

	// Token: 0x04004F10 RID: 20240
	public Vector2 offset;

	// Token: 0x04004F11 RID: 20241
	public ETCButton centerButton;

	// Token: 0x04004F12 RID: 20242
	public ETCButton[] buttonList = new ETCButton[0];
}
