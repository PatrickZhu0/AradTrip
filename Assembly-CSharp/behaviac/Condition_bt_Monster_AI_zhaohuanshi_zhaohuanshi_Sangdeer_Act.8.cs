using System;

namespace behaviac
{
	// Token: 0x02003FF3 RID: 16371
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node15 : Condition
	{
		// Token: 0x0601674C RID: 91980 RVA: 0x006CBA37 File Offset: 0x006C9E37
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601674D RID: 91981 RVA: 0x006CBA6C File Offset: 0x006C9E6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF9C RID: 65436
		private int opl_p0;

		// Token: 0x0400FF9D RID: 65437
		private int opl_p1;

		// Token: 0x0400FF9E RID: 65438
		private int opl_p2;

		// Token: 0x0400FF9F RID: 65439
		private int opl_p3;
	}
}
