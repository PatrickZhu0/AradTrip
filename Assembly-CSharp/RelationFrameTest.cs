using System;
using GameClient;

// Token: 0x020019EE RID: 6638
internal class RelationFrameTest : ClientFrame
{
	// Token: 0x0601047D RID: 66685 RVA: 0x00490110 File Offset: 0x0048E510
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Test/TitleImage";
	}

	// Token: 0x0601047E RID: 66686 RVA: 0x00490117 File Offset: 0x0048E517
	protected override void _OnOpenFrame()
	{
	}

	// Token: 0x0601047F RID: 66687 RVA: 0x00490119 File Offset: 0x0048E519
	protected override void _OnCloseFrame()
	{
	}

	// Token: 0x06010480 RID: 66688 RVA: 0x0049011B File Offset: 0x0048E51B
	[UIEventHandle("Panel/Exist/Button")]
	private void OnClickClose()
	{
		this.frameMgr.CloseFrame<RelationFrameTest>(this, false);
	}

	// Token: 0x06010481 RID: 66689 RVA: 0x0049012A File Offset: 0x0048E52A
	[UIEventHandle("Bottom/Button")]
	private void OnOpen1()
	{
		this.frameMgr.OpenFrame<RelationFrameDialogTest>(FrameLayer.Middle, null, string.Empty);
	}

	// Token: 0x06010482 RID: 66690 RVA: 0x0049013F File Offset: 0x0048E53F
	[UIEventHandle("Bottom/ButtonList")]
	private void OnOpen2()
	{
		this.frameMgr.OpenFrame<RelationFramePopupTest>(FrameLayer.Middle, null, string.Empty);
	}
}
