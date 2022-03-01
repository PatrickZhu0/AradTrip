using System;

namespace behaviac
{
	// Token: 0x02001FDC RID: 8156
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node38 : Condition
	{
		// Token: 0x06012955 RID: 76117 RVA: 0x00571ED7 File Offset: 0x005702D7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012956 RID: 76118 RVA: 0x00571F0C File Offset: 0x0057030C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C346 RID: 49990
		private int opl_p0;

		// Token: 0x0400C347 RID: 49991
		private int opl_p1;

		// Token: 0x0400C348 RID: 49992
		private int opl_p2;

		// Token: 0x0400C349 RID: 49993
		private int opl_p3;
	}
}
