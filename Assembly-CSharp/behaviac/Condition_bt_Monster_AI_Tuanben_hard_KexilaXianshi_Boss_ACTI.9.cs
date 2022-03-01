using System;

namespace behaviac
{
	// Token: 0x02003C73 RID: 15475
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node54 : Condition
	{
		// Token: 0x0601608D RID: 90253 RVA: 0x006A8CF7 File Offset: 0x006A70F7
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node54()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x0601608E RID: 90254 RVA: 0x006A8D18 File Offset: 0x006A7118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F918 RID: 63768
		private HMType opl_p0;

		// Token: 0x0400F919 RID: 63769
		private BE_Operation opl_p1;

		// Token: 0x0400F91A RID: 63770
		private float opl_p2;
	}
}
