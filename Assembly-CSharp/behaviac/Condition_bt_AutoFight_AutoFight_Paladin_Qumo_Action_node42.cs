using System;

namespace behaviac
{
	// Token: 0x0200280F RID: 10255
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node42 : Condition
	{
		// Token: 0x0601395D RID: 80221 RVA: 0x005D67CE File Offset: 0x005D4BCE
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node42()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601395E RID: 80222 RVA: 0x005D6804 File Offset: 0x005D4C04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3BB RID: 54203
		private int opl_p0;

		// Token: 0x0400D3BC RID: 54204
		private int opl_p1;

		// Token: 0x0400D3BD RID: 54205
		private int opl_p2;

		// Token: 0x0400D3BE RID: 54206
		private int opl_p3;
	}
}
