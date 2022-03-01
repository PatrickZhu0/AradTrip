using System;
using GameClient;

// Token: 0x020043EA RID: 17386
public class Mechanism43 : BeMechanism
{
	// Token: 0x0601821B RID: 98843 RVA: 0x007811AB File Offset: 0x0077F5AB
	public Mechanism43(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601821C RID: 98844 RVA: 0x007811C0 File Offset: 0x0077F5C0
	public override void OnInit()
	{
		this.m_AniPath = this.data.StringValueA[0];
		this.m_DelayRemoveTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x0601821D RID: 98845 RVA: 0x0078120C File Offset: 0x0077F60C
	public override void OnStart()
	{
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null && base.owner.isLocalActor)
		{
			clientSystemBattle.PlayCharacterAni(base.owner.GetFace(), this.m_AniPath, this.m_DelayRemoveTime);
		}
	}

	// Token: 0x04011678 RID: 71288
	protected int m_DelayRemoveTime;

	// Token: 0x04011679 RID: 71289
	protected string m_AniPath = "UIFlatten/Animation/Hero_Zhengui_Guiyingshan";
}
