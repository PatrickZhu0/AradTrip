using System;
using GameClient;

// Token: 0x020019EF RID: 6639
internal class RelationFramePopupTest : ClientFrame
{
	// Token: 0x06010484 RID: 66692 RVA: 0x0049015C File Offset: 0x0048E55C
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Test/PopupDialog";
	}

	// Token: 0x06010485 RID: 66693 RVA: 0x00490163 File Offset: 0x0048E563
	protected override void _OnOpenFrame()
	{
	}

	// Token: 0x06010486 RID: 66694 RVA: 0x00490165 File Offset: 0x0048E565
	protected override void _OnCloseFrame()
	{
	}

	// Token: 0x06010487 RID: 66695 RVA: 0x00490167 File Offset: 0x0048E567
	[UIEventHandle("Title/Button")]
	private void OnClickClose()
	{
		this.frameMgr.CloseFrame<RelationFramePopupTest>(this, false);
	}
}
