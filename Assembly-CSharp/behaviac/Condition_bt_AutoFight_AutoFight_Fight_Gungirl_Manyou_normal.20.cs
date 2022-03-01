using System;

namespace behaviac
{
	// Token: 0x0200205F RID: 8287
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node48 : Condition
	{
		// Token: 0x06012A58 RID: 76376 RVA: 0x0057801F File Offset: 0x0057641F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node48()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012A59 RID: 76377 RVA: 0x00578054 File Offset: 0x00576454
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C44A RID: 50250
		private int opl_p0;

		// Token: 0x0400C44B RID: 50251
		private int opl_p1;

		// Token: 0x0400C44C RID: 50252
		private int opl_p2;

		// Token: 0x0400C44D RID: 50253
		private int opl_p3;
	}
}
