using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000F15 RID: 3861
public class ComSwitchNode : ComBaseComponet
{
	// Token: 0x1700191B RID: 6427
	// (get) Token: 0x060096AA RID: 38570 RVA: 0x001CB467 File Offset: 0x001C9867
	// (set) Token: 0x060096AB RID: 38571 RVA: 0x001CB46F File Offset: 0x001C986F
	public ComSwitchNode.eState state { get; private set; }

	// Token: 0x060096AC RID: 38572 RVA: 0x001CB478 File Offset: 0x001C9878
	protected override void _bindExUI()
	{
		this.mSwitch = this.mBind.GetCom<Toggle>("switch");
		this.mSwitch.onValueChanged.AddListener(new UnityAction<bool>(this._onSwitchToggleValueChange));
		this.mContent = this.mBind.GetGameObject("content");
		this.mSwitchgroup = this.mBind.GetCom<ToggleGroup>("switchgroup");
		this.mStateoff = this.mBind.GetGameObject("stateoff");
		this.mStateon = this.mBind.GetGameObject("stateon");
	}

	// Token: 0x060096AD RID: 38573 RVA: 0x001CB510 File Offset: 0x001C9910
	protected override void _unbindExUI()
	{
		this.mSwitch.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSwitchToggleValueChange));
		this.mSwitch = null;
		this.mContent = null;
		this.mSwitchgroup = null;
		this.mStateoff = null;
		this.mStateon = null;
	}

	// Token: 0x060096AE RID: 38574 RVA: 0x001CB55C File Offset: 0x001C995C
	private void _onSwitchToggleValueChange(bool changed)
	{
		this.state = ((!changed) ? ComSwitchNode.eState.Close : ComSwitchNode.eState.Open);
		if (null != this.mContent)
		{
			this.mContent.SetActive(changed);
		}
		if (null != this.mStateon)
		{
			this.mStateon.SetActive(changed);
		}
		if (null != this.mStateoff)
		{
			this.mStateoff.SetActive(!changed);
		}
	}

	// Token: 0x060096AF RID: 38575 RVA: 0x001CB5D6 File Offset: 0x001C99D6
	public void Reset()
	{
		this.ClearSubItem();
		this._onSwitchToggleValueChange(false);
	}

	// Token: 0x060096B0 RID: 38576 RVA: 0x001CB5E8 File Offset: 0x001C99E8
	public ComCommonBind AddOneSubItem()
	{
		string prefabPath = this.mBind.GetPrefabPath("unit");
		ComCommonBind comCommonBind = null;
		if (!string.IsNullOrEmpty(prefabPath))
		{
			comCommonBind = this.mBind.LoadExtraBind(prefabPath);
			if (null != comCommonBind)
			{
				Utility.AttachTo(comCommonBind.gameObject, this.mContent, false);
			}
		}
		return comCommonBind;
	}

	// Token: 0x060096B1 RID: 38577 RVA: 0x001CB640 File Offset: 0x001C9A40
	public void ClearSubItem()
	{
		string prefabPath = this.mBind.GetPrefabPath("unit");
		if (!string.IsNullOrEmpty(prefabPath))
		{
			this.mBind.ClearCacheBinds(prefabPath);
		}
	}

	// Token: 0x04004D7D RID: 19837
	private Toggle mSwitch;

	// Token: 0x04004D7E RID: 19838
	private GameObject mContent;

	// Token: 0x04004D7F RID: 19839
	private ToggleGroup mSwitchgroup;

	// Token: 0x04004D80 RID: 19840
	private GameObject mStateoff;

	// Token: 0x04004D81 RID: 19841
	private GameObject mStateon;

	// Token: 0x02000F16 RID: 3862
	public enum eState
	{
		// Token: 0x04004D83 RID: 19843
		Open,
		// Token: 0x04004D84 RID: 19844
		Close
	}
}
