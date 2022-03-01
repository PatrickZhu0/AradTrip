using System;

namespace behaviac
{
	// Token: 0x02004047 RID: 16455
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node26 : Condition
	{
		// Token: 0x060167ED RID: 92141 RVA: 0x006CEF8B File Offset: 0x006CD38B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node26()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167EE RID: 92142 RVA: 0x006CEFC0 File Offset: 0x006CD3C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010037 RID: 65591
		private int opl_p0;

		// Token: 0x04010038 RID: 65592
		private int opl_p1;

		// Token: 0x04010039 RID: 65593
		private int opl_p2;

		// Token: 0x0401003A RID: 65594
		private int opl_p3;
	}
}
