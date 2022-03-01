using System;

namespace behaviac
{
	// Token: 0x02003FAA RID: 16298
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node41 : Condition
	{
		// Token: 0x060166BE RID: 91838 RVA: 0x006C82CB File Offset: 0x006C66CB
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node41()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060166BF RID: 91839 RVA: 0x006C8300 File Offset: 0x006C6700
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF10 RID: 65296
		private int opl_p0;

		// Token: 0x0400FF11 RID: 65297
		private int opl_p1;

		// Token: 0x0400FF12 RID: 65298
		private int opl_p2;

		// Token: 0x0400FF13 RID: 65299
		private int opl_p3;
	}
}
