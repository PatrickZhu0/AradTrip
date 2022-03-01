using System;

namespace behaviac
{
	// Token: 0x0200255C RID: 9564
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node100 : Condition
	{
		// Token: 0x06013401 RID: 78849 RVA: 0x005B7AB2 File Offset: 0x005B5EB2
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node100()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013402 RID: 78850 RVA: 0x005B7AE8 File Offset: 0x005B5EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE27 RID: 52775
		private int opl_p0;

		// Token: 0x0400CE28 RID: 52776
		private int opl_p1;

		// Token: 0x0400CE29 RID: 52777
		private int opl_p2;

		// Token: 0x0400CE2A RID: 52778
		private int opl_p3;
	}
}
