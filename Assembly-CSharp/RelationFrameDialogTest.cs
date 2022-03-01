using System;
using GameClient;

// Token: 0x020019F0 RID: 6640
internal class RelationFrameDialogTest : ClientFrame
{
	// Token: 0x06010489 RID: 66697 RVA: 0x0049017E File Offset: 0x0048E57E
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Test/Dialog";
	}

	// Token: 0x0601048A RID: 66698 RVA: 0x00490185 File Offset: 0x0048E585
	protected override void _OnOpenFrame()
	{
	}

	// Token: 0x0601048B RID: 66699 RVA: 0x00490187 File Offset: 0x0048E587
	protected override void _OnCloseFrame()
	{
	}

	// Token: 0x0601048C RID: 66700 RVA: 0x00490189 File Offset: 0x0048E589
	[UIEventHandle("Ok")]
	private void OnClickClose()
	{
		this.frameMgr.CloseFrame<RelationFrameDialogTest>(this, false);
	}
}
