using System;

namespace behaviac
{
	// Token: 0x0200361C RID: 13852
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node27 : Condition
	{
		// Token: 0x0601545C RID: 87132 RVA: 0x00669E92 File Offset: 0x00668292
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node27()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601545D RID: 87133 RVA: 0x00669EC8 File Offset: 0x006682C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE15 RID: 60949
		private int opl_p0;

		// Token: 0x0400EE16 RID: 60950
		private int opl_p1;

		// Token: 0x0400EE17 RID: 60951
		private int opl_p2;

		// Token: 0x0400EE18 RID: 60952
		private int opl_p3;
	}
}
