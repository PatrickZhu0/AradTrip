using System;

namespace behaviac
{
	// Token: 0x0200251C RID: 9500
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node109 : Condition
	{
		// Token: 0x06013381 RID: 78721 RVA: 0x005B5F12 File Offset: 0x005B4312
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node109()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013382 RID: 78722 RVA: 0x005B5F48 File Offset: 0x005B4348
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDA3 RID: 52643
		private int opl_p0;

		// Token: 0x0400CDA4 RID: 52644
		private int opl_p1;

		// Token: 0x0400CDA5 RID: 52645
		private int opl_p2;

		// Token: 0x0400CDA6 RID: 52646
		private int opl_p3;
	}
}
