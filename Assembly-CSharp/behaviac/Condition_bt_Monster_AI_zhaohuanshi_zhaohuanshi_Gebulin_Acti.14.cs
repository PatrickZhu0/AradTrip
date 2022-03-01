using System;

namespace behaviac
{
	// Token: 0x02003F9E RID: 16286
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node26 : Condition
	{
		// Token: 0x060166A6 RID: 91814 RVA: 0x006C7DAF File Offset: 0x006C61AF
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node26()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060166A7 RID: 91815 RVA: 0x006C7DE4 File Offset: 0x006C61E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEF8 RID: 65272
		private int opl_p0;

		// Token: 0x0400FEF9 RID: 65273
		private int opl_p1;

		// Token: 0x0400FEFA RID: 65274
		private int opl_p2;

		// Token: 0x0400FEFB RID: 65275
		private int opl_p3;
	}
}
