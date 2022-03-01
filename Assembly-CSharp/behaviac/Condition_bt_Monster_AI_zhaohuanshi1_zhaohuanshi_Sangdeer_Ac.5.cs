using System;

namespace behaviac
{
	// Token: 0x02004098 RID: 16536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node10 : Condition
	{
		// Token: 0x0601688B RID: 92299 RVA: 0x006D2A5F File Offset: 0x006D0E5F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601688C RID: 92300 RVA: 0x006D2A94 File Offset: 0x006D0E94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100D3 RID: 65747
		private int opl_p0;

		// Token: 0x040100D4 RID: 65748
		private int opl_p1;

		// Token: 0x040100D5 RID: 65749
		private int opl_p2;

		// Token: 0x040100D6 RID: 65750
		private int opl_p3;
	}
}
