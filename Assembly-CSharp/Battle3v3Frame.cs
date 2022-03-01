using System;
using GameClient;
using UnityEngine;

// Token: 0x020010EA RID: 4330
public class Battle3v3Frame : ClientFrame
{
	// Token: 0x0600A430 RID: 42032 RVA: 0x0021C3AA File Offset: 0x0021A7AA
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/UIComponent/Battle3v3Frame";
	}

	// Token: 0x0600A431 RID: 42033 RVA: 0x0021C3B1 File Offset: 0x0021A7B1
	protected override void _bindExUI()
	{
		this.m3v3TipsRoot = this.mBind.GetGameObject("3v3TipsRoot");
	}

	// Token: 0x0600A432 RID: 42034 RVA: 0x0021C3C9 File Offset: 0x0021A7C9
	protected override void _unbindExUI()
	{
		this.m3v3TipsRoot = null;
	}

	// Token: 0x0600A433 RID: 42035 RVA: 0x0021C3D2 File Offset: 0x0021A7D2
	public void ShowPVP3V3Tips()
	{
		if (null == this.m3v3TipsRoot)
		{
			return;
		}
		this.m3v3TipsRoot.CustomActive(true);
	}

	// Token: 0x0600A434 RID: 42036 RVA: 0x0021C3F2 File Offset: 0x0021A7F2
	public void HiddenPVP3V3Tips()
	{
		if (null == this.m3v3TipsRoot)
		{
			return;
		}
		this.m3v3TipsRoot.CustomActive(false);
	}

	// Token: 0x04005BCF RID: 23503
	private GameObject m3v3TipsRoot;
}
