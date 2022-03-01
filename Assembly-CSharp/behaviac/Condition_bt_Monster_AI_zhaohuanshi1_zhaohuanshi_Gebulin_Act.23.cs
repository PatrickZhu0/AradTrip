using System;

namespace behaviac
{
	// Token: 0x02004053 RID: 16467
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node41 : Condition
	{
		// Token: 0x06016805 RID: 92165 RVA: 0x006CF4A7 File Offset: 0x006CD8A7
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node41()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06016806 RID: 92166 RVA: 0x006CF4DC File Offset: 0x006CD8DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401004F RID: 65615
		private int opl_p0;

		// Token: 0x04010050 RID: 65616
		private int opl_p1;

		// Token: 0x04010051 RID: 65617
		private int opl_p2;

		// Token: 0x04010052 RID: 65618
		private int opl_p3;
	}
}
