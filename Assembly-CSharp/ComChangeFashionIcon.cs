using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001722 RID: 5922
public class ComChangeFashionIcon : MonoBehaviour
{
	// Token: 0x0600E8A4 RID: 59556 RVA: 0x003D895C File Offset: 0x003D6D5C
	private void Start()
	{
		if (this.fashionIcon == null)
		{
			return;
		}
		this.normalIcon = Utility.GetComponetInChild<Image>(this.fashionIcon, "Icon");
		this.checkedIcon = Utility.GetComponetInChild<Image>(this.fashionIcon, "Icon/Icon (1)");
		this.toggle = base.GetComponent<Toggle>();
		if (this.toggle)
		{
			this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleOn));
			this.SetIconChecked(this.toggle.isOn);
		}
	}

	// Token: 0x0600E8A5 RID: 59557 RVA: 0x003D89F0 File Offset: 0x003D6DF0
	private void OnDestroy()
	{
		if (this.toggle)
		{
			this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleOn));
			this.toggle = null;
		}
	}

	// Token: 0x0600E8A6 RID: 59558 RVA: 0x003D8A25 File Offset: 0x003D6E25
	private void OnToggleOn(bool isOn)
	{
		this.SetIconChecked(isOn);
	}

	// Token: 0x0600E8A7 RID: 59559 RVA: 0x003D8A2E File Offset: 0x003D6E2E
	private void SetIconChecked(bool isChecked)
	{
		if (this.normalIcon)
		{
			this.normalIcon.enabled = !isChecked;
		}
		if (this.checkedIcon)
		{
			this.checkedIcon.enabled = isChecked;
		}
	}

	// Token: 0x04008D04 RID: 36100
	private const string normalIconPath = "Icon";

	// Token: 0x04008D05 RID: 36101
	private const string checkedIconPath = "Icon/Icon (1)";

	// Token: 0x04008D06 RID: 36102
	public GameObject fashionIcon;

	// Token: 0x04008D07 RID: 36103
	private Image normalIcon;

	// Token: 0x04008D08 RID: 36104
	private Image checkedIcon;

	// Token: 0x04008D09 RID: 36105
	private Toggle toggle;
}
