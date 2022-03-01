using System;

namespace behaviac
{
	// Token: 0x020036D1 RID: 14033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node6 : Condition
	{
		// Token: 0x060155B9 RID: 87481 RVA: 0x00671802 File Offset: 0x0066FC02
		public Condition_bt_Monster_AI_Monster_Luguyouchong_Monster_Luguyouchongxiao_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060155BA RID: 87482 RVA: 0x00671838 File Offset: 0x0066FC38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF8B RID: 61323
		private int opl_p0;

		// Token: 0x0400EF8C RID: 61324
		private int opl_p1;

		// Token: 0x0400EF8D RID: 61325
		private int opl_p2;

		// Token: 0x0400EF8E RID: 61326
		private int opl_p3;
	}
}
