using System;
using Battle;
using GameClient;
using UnityEngine;

// Token: 0x02004220 RID: 16928
public class Buff2000003 : BeBuff
{
	// Token: 0x060176ED RID: 95981 RVA: 0x0073319E File Offset: 0x0073159E
	public Buff2000003(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176EE RID: 95982 RVA: 0x007331B7 File Offset: 0x007315B7
	public override void OnInit()
	{
		this.m_CountDownPrefab = Singleton<CGameObjectPool>.instance.GetGameObject(this.m_CountDownPath, enResourceType.BattleScene, 2U);
	}

	// Token: 0x060176EF RID: 95983 RVA: 0x007331D1 File Offset: 0x007315D1
	public override void OnStart()
	{
		this._AddCountPrefab();
	}

	// Token: 0x060176F0 RID: 95984 RVA: 0x007331DC File Offset: 0x007315DC
	protected void _AddCountPrefab()
	{
		ShowCountDownComponent component = this.m_CountDownPrefab.GetComponent<ShowCountDownComponent>();
		component.InitData(3);
		GeUtility.AttachTo(this.m_CountDownPrefab, base.owner.m_pkGeActor.goInfoBar, false);
	}

	// Token: 0x04010D30 RID: 68912
	protected string m_CountDownPath = "UIFlatten/Prefabs/BattleUI/DungeonCountDown";

	// Token: 0x04010D31 RID: 68913
	protected GameObject m_CountDownPrefab;
}
