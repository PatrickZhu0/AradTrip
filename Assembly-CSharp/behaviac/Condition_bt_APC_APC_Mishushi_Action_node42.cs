using System;

namespace behaviac
{
	// Token: 0x02001DCB RID: 7627
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node42 : Condition
	{
		// Token: 0x0601254E RID: 75086 RVA: 0x0055A2B6 File Offset: 0x005586B6
		public Condition_bt_APC_APC_Mishushi_Action_node42()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601254F RID: 75087 RVA: 0x0055A2EC File Offset: 0x005586EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF42 RID: 48962
		private int opl_p0;

		// Token: 0x0400BF43 RID: 48963
		private int opl_p1;

		// Token: 0x0400BF44 RID: 48964
		private int opl_p2;

		// Token: 0x0400BF45 RID: 48965
		private int opl_p3;
	}
}
