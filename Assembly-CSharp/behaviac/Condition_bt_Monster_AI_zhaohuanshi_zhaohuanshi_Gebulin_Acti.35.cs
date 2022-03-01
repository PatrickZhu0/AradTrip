using System;

namespace behaviac
{
	// Token: 0x02003FBA RID: 16314
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node61 : Condition
	{
		// Token: 0x060166DE RID: 91870 RVA: 0x006C899B File Offset: 0x006C6D9B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node61()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060166DF RID: 91871 RVA: 0x006C89D0 File Offset: 0x006C6DD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF30 RID: 65328
		private int opl_p0;

		// Token: 0x0400FF31 RID: 65329
		private int opl_p1;

		// Token: 0x0400FF32 RID: 65330
		private int opl_p2;

		// Token: 0x0400FF33 RID: 65331
		private int opl_p3;
	}
}
