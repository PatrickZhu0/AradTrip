using System;

namespace behaviac
{
	// Token: 0x02002664 RID: 9828
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node32 : Condition
	{
		// Token: 0x0601360D RID: 79373 RVA: 0x005C456A File Offset: 0x005C296A
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node32()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601360E RID: 79374 RVA: 0x005C45A0 File Offset: 0x005C29A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D05E RID: 53342
		private int opl_p0;

		// Token: 0x0400D05F RID: 53343
		private int opl_p1;

		// Token: 0x0400D060 RID: 53344
		private int opl_p2;

		// Token: 0x0400D061 RID: 53345
		private int opl_p3;
	}
}
