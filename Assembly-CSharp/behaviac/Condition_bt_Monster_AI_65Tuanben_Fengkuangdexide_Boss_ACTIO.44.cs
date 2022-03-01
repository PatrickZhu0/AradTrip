using System;

namespace behaviac
{
	// Token: 0x02002EEA RID: 12010
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node60 : Condition
	{
		// Token: 0x060146AE RID: 83630 RVA: 0x0062348E File Offset: 0x0062188E
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node60()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 570297;
		}

		// Token: 0x060146AF RID: 83631 RVA: 0x006234B0 File Offset: 0x006218B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E028 RID: 57384
		private BE_Target opl_p0;

		// Token: 0x0400E029 RID: 57385
		private BE_Equal opl_p1;

		// Token: 0x0400E02A RID: 57386
		private int opl_p2;
	}
}
