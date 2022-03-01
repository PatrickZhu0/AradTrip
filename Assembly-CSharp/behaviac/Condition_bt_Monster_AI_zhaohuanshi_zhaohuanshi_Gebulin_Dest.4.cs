using System;

namespace behaviac
{
	// Token: 0x02003FC2 RID: 16322
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node10 : Condition
	{
		// Token: 0x060166ED RID: 91885 RVA: 0x006C9AEB File Offset: 0x006C7EEB
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node10()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060166EE RID: 91886 RVA: 0x006C9B20 File Offset: 0x006C7F20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF3E RID: 65342
		private int opl_p0;

		// Token: 0x0400FF3F RID: 65343
		private int opl_p1;

		// Token: 0x0400FF40 RID: 65344
		private int opl_p2;

		// Token: 0x0400FF41 RID: 65345
		private int opl_p3;
	}
}
