using System;

namespace behaviac
{
	// Token: 0x0200299A RID: 10650
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node122 : Condition
	{
		// Token: 0x06013C68 RID: 81000 RVA: 0x005EA48F File Offset: 0x005E888F
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node122()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013C69 RID: 81001 RVA: 0x005EA4C4 File Offset: 0x005E88C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6D3 RID: 54995
		private int opl_p0;

		// Token: 0x0400D6D4 RID: 54996
		private int opl_p1;

		// Token: 0x0400D6D5 RID: 54997
		private int opl_p2;

		// Token: 0x0400D6D6 RID: 54998
		private int opl_p3;
	}
}
