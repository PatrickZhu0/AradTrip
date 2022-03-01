using System;
using GameClient;
using UnityEngine.UI;

// Token: 0x0200159B RID: 5531
public class SkillComboDesFrame : ClientFrame
{
	// Token: 0x0600D865 RID: 55397 RVA: 0x00362546 File Offset: 0x00360946
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/SkillComboDesFrame";
	}

	// Token: 0x0600D866 RID: 55398 RVA: 0x0036254D File Offset: 0x0036094D
	protected override void _bindExUI()
	{
		base._bindExUI();
		this.btnClick = this.mBind.GetCom<Button>("btnClick");
		this.background = this.mBind.GetCom<Image>("background");
	}

	// Token: 0x0600D867 RID: 55399 RVA: 0x00362581 File Offset: 0x00360981
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
		this.btnClick.onClick.RemoveAllListeners();
		this.btnClick.onClick.AddListener(delegate()
		{
			base.Close(false);
		});
	}

	// Token: 0x0600D868 RID: 55400 RVA: 0x003625B5 File Offset: 0x003609B5
	protected override void _OnCloseFrame()
	{
		base._OnCloseFrame();
	}

	// Token: 0x0600D869 RID: 55401 RVA: 0x003625BD File Offset: 0x003609BD
	protected override void _unbindExUI()
	{
		base._unbindExUI();
	}

	// Token: 0x04007F0F RID: 32527
	private Button btnClick;

	// Token: 0x04007F10 RID: 32528
	private Image background;
}
