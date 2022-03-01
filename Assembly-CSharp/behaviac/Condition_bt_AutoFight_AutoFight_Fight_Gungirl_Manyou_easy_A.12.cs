using System;

namespace behaviac
{
	// Token: 0x02001FD4 RID: 8148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node28 : Condition
	{
		// Token: 0x06012945 RID: 76101 RVA: 0x00571B9F File Offset: 0x0056FF9F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node28()
		{
			this.opl_p0 = 1800;
			this.opl_p1 = 500;
			this.opl_p2 = 1800;
			this.opl_p3 = 1800;
		}

		// Token: 0x06012946 RID: 76102 RVA: 0x00571BD4 File Offset: 0x0056FFD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C336 RID: 49974
		private int opl_p0;

		// Token: 0x0400C337 RID: 49975
		private int opl_p1;

		// Token: 0x0400C338 RID: 49976
		private int opl_p2;

		// Token: 0x0400C339 RID: 49977
		private int opl_p3;
	}
}
