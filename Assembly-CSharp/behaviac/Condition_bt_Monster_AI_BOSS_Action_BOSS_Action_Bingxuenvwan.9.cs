using System;

namespace behaviac
{
	// Token: 0x02002F79 RID: 12153
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node14 : Condition
	{
		// Token: 0x060147C0 RID: 83904 RVA: 0x0062A19E File Offset: 0x0062859E
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_Bingxuenvwang_Action_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.4f;
		}

		// Token: 0x060147C1 RID: 83905 RVA: 0x0062A1C0 File Offset: 0x006285C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E12A RID: 57642
		private HMType opl_p0;

		// Token: 0x0400E12B RID: 57643
		private BE_Operation opl_p1;

		// Token: 0x0400E12C RID: 57644
		private float opl_p2;
	}
}
