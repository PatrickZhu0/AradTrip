using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200195E RID: 6494
[RequireComponent(typeof(Toggle))]
public class PayRewardLevelTab : MonoBehaviour
{
	// Token: 0x17001D12 RID: 7442
	// (get) Token: 0x0600FC77 RID: 64631 RVA: 0x00456769 File Offset: 0x00454B69
	// (set) Token: 0x0600FC78 RID: 64632 RVA: 0x00456771 File Offset: 0x00454B71
	public int PayRewardLevelIndex { get; private set; }

	// Token: 0x0600FC79 RID: 64633 RVA: 0x0045677A File Offset: 0x00454B7A
	public void SetPayRewardLevelIndex(int index)
	{
		this.PayRewardLevelIndex = index;
	}

	// Token: 0x0600FC7A RID: 64634 RVA: 0x00456784 File Offset: 0x00454B84
	public void Initialize()
	{
		this.toggle = base.GetComponent<Toggle>();
		if (this.toggle)
		{
			this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleValueChanged));
		}
		this.toggleText = Utility.GetComponetInChild<Text>(base.gameObject, "TabText");
		this.isInited = true;
	}

	// Token: 0x0600FC7B RID: 64635 RVA: 0x004567E8 File Offset: 0x00454BE8
	public void Clear()
	{
		if (this.toggle)
		{
			this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleValueChanged));
			this.toggle = null;
		}
		this.toggleText = null;
		this.onPayRewardLevelTabChanged = null;
		this.isInited = false;
		this.isManualActive = false;
	}

	// Token: 0x0600FC7C RID: 64636 RVA: 0x00456844 File Offset: 0x00454C44
	public void SetTabText(string desc)
	{
		if (this.toggleText)
		{
			this.toggleText.text = desc;
		}
	}

	// Token: 0x0600FC7D RID: 64637 RVA: 0x00456862 File Offset: 0x00454C62
	public void SetTabActive(bool isOn)
	{
		if (this.toggle)
		{
			this.toggle.isOn = isOn;
		}
	}

	// Token: 0x0600FC7E RID: 64638 RVA: 0x00456880 File Offset: 0x00454C80
	public void OnToggleValueChanged(bool isOn)
	{
		if (!this.isInited)
		{
			return;
		}
		if (isOn && this.onPayRewardLevelTabChanged != null)
		{
			this.onPayRewardLevelTabChanged();
		}
	}

	// Token: 0x04009E3A RID: 40506
	private bool isInited;

	// Token: 0x04009E3B RID: 40507
	private bool isManualActive;

	// Token: 0x04009E3D RID: 40509
	public Toggle toggle;

	// Token: 0x04009E3E RID: 40510
	public Text toggleText;

	// Token: 0x04009E3F RID: 40511
	public PayRewardLevelTab.OnPayRewardLevelTabChanged onPayRewardLevelTabChanged;

	// Token: 0x0200195F RID: 6495
	// (Invoke) Token: 0x0600FC80 RID: 64640
	public delegate void OnPayRewardLevelTabChanged();
}
