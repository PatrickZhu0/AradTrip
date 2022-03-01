using System;

namespace behaviac
{
	// Token: 0x02002EF9 RID: 12025
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node28 : Condition
	{
		// Token: 0x060146CA RID: 83658 RVA: 0x00624C4D File Offset: 0x0062304D
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node28()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.6f;
		}

		// Token: 0x060146CB RID: 83659 RVA: 0x00624C70 File Offset: 0x00623070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E03C RID: 57404
		private HMType opl_p0;

		// Token: 0x0400E03D RID: 57405
		private BE_Operation opl_p1;

		// Token: 0x0400E03E RID: 57406
		private float opl_p2;
	}
}
