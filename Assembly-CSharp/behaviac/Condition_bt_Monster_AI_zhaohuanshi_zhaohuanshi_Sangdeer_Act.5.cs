using System;

namespace behaviac
{
	// Token: 0x02003FEF RID: 16367
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node10 : Condition
	{
		// Token: 0x06016744 RID: 91972 RVA: 0x006CB883 File Offset: 0x006C9C83
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016745 RID: 91973 RVA: 0x006CB8B8 File Offset: 0x006C9CB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF94 RID: 65428
		private int opl_p0;

		// Token: 0x0400FF95 RID: 65429
		private int opl_p1;

		// Token: 0x0400FF96 RID: 65430
		private int opl_p2;

		// Token: 0x0400FF97 RID: 65431
		private int opl_p3;
	}
}
