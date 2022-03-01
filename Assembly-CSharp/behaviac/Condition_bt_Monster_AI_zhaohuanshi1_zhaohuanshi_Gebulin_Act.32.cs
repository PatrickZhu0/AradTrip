using System;

namespace behaviac
{
	// Token: 0x0200405F RID: 16479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node56 : Condition
	{
		// Token: 0x0601681D RID: 92189 RVA: 0x006CF9C3 File Offset: 0x006CDDC3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node56()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x0601681E RID: 92190 RVA: 0x006CF9F8 File Offset: 0x006CDDF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010067 RID: 65639
		private int opl_p0;

		// Token: 0x04010068 RID: 65640
		private int opl_p1;

		// Token: 0x04010069 RID: 65641
		private int opl_p2;

		// Token: 0x0401006A RID: 65642
		private int opl_p3;
	}
}
