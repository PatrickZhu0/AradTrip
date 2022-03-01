using System;

namespace behaviac
{
	// Token: 0x02004094 RID: 16532
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node5 : Condition
	{
		// Token: 0x06016883 RID: 92291 RVA: 0x006D28AB File Offset: 0x006D0CAB
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016884 RID: 92292 RVA: 0x006D28E0 File Offset: 0x006D0CE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100CB RID: 65739
		private int opl_p0;

		// Token: 0x040100CC RID: 65740
		private int opl_p1;

		// Token: 0x040100CD RID: 65741
		private int opl_p2;

		// Token: 0x040100CE RID: 65742
		private int opl_p3;
	}
}
