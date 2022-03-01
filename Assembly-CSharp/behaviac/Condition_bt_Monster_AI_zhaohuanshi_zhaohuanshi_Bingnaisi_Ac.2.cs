using System;

namespace behaviac
{
	// Token: 0x02003F7A RID: 16250
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node7 : Condition
	{
		// Token: 0x06016660 RID: 91744 RVA: 0x006C697B File Offset: 0x006C4D7B
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node7()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016661 RID: 91745 RVA: 0x006C69B0 File Offset: 0x006C4DB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEB4 RID: 65204
		private int opl_p0;

		// Token: 0x0400FEB5 RID: 65205
		private int opl_p1;

		// Token: 0x0400FEB6 RID: 65206
		private int opl_p2;

		// Token: 0x0400FEB7 RID: 65207
		private int opl_p3;
	}
}
