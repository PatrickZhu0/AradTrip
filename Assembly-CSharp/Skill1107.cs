using System;
using System.Collections.Generic;
using GameClient;

// Token: 0x02004437 RID: 17463
public class Skill1107 : BeSkill
{
	// Token: 0x060183FA RID: 99322 RVA: 0x0078CF24 File Offset: 0x0078B324
	public Skill1107(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183FB RID: 99323 RVA: 0x0078CF54 File Offset: 0x0078B354
	public override void OnPostInit()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.ConfigCommand, delegate(object[] args)
		{
			if (this.skillData.ValueA.Count > 1)
			{
				int num = base.owner.autoHitConfig ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true) : TableManager.GetValueFromUnionCell((!this.isPVP()) ? this.skillData.ValueA[1] : this.skillData.ValueA[0], base.level, true);
				if (num > 0 && base.owner != null)
				{
					base.owner.buffController.RemoveTriggerBuff(num);
					BuffInfoData buffInfo = new BuffInfoData(num, base.level, 0);
					base.owner.buffController.AddTriggerBuff(buffInfo);
				}
			}
		});
		this.range = VInt.Float2VIntValue((float)TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true) / 1000f);
	}

	// Token: 0x060183FC RID: 99324 RVA: 0x0078CFB4 File Offset: 0x0078B3B4
	public override bool CanUseSkill()
	{
		bool flag = true;
		if (base.owner.autoHitConfig)
		{
			flag = (base.owner.GetCurrentBtnState() == ButtonState.PRESS);
		}
		base.owner.CurrentBeScene.FindActorInRange(this.actorList, base.owner.GetPosition(), this.range, (base.owner.GetCamp() != 0) ? 0 : 1, 0);
		bool flag2 = base.CanUseSkill();
		return flag2 && base.owner.sgGetCurrentState() == 4 && base.owner.GetPosition().z <= 0 && this.actorList.Count > 0 && !base.owner.IsDead() && flag && !this.HaveBuff();
	}

	// Token: 0x060183FD RID: 99325 RVA: 0x0078D08C File Offset: 0x0078B48C
	private bool HaveBuff()
	{
		BeBuff beBuff = base.owner.buffController.GetBuffList().Find((BeBuff x) => x.buffID == 370500 || x.buffID == 370501);
		return beBuff != null;
	}

	// Token: 0x060183FE RID: 99326 RVA: 0x0078D0D3 File Offset: 0x0078B4D3
	public bool canUseSkill()
	{
		return base.CanUseSkill();
	}

	// Token: 0x060183FF RID: 99327 RVA: 0x0078D0DB File Offset: 0x0078B4DB
	public bool isPVP()
	{
		return BattleMain.IsModePvP(base.battleType);
	}

	// Token: 0x06018400 RID: 99328 RVA: 0x0078D0E8 File Offset: 0x0078B4E8
	public override bool CheckSpellCondition(ActionState state)
	{
		return base.owner.sgGetCurrentState() == 4 && base.owner.GetPosition().z <= 0;
	}

	// Token: 0x040117FF RID: 71679
	public VInt range = default(VInt);

	// Token: 0x04011800 RID: 71680
	private int buffInfoID;

	// Token: 0x04011801 RID: 71681
	protected List<BeActor> actorList = new List<BeActor>();
}
