using System;

namespace behaviac
{
	// Token: 0x02003FA2 RID: 16290
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node31 : Condition
	{
		// Token: 0x060166AE RID: 91822 RVA: 0x006C7F63 File Offset: 0x006C6363
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node31()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060166AF RID: 91823 RVA: 0x006C7F98 File Offset: 0x006C6398
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF00 RID: 65280
		private int opl_p0;

		// Token: 0x0400FF01 RID: 65281
		private int opl_p1;

		// Token: 0x0400FF02 RID: 65282
		private int opl_p2;

		// Token: 0x0400FF03 RID: 65283
		private int opl_p3;
	}
}
