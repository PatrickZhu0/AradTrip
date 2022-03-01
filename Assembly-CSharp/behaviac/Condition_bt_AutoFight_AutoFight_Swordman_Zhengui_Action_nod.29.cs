using System;

namespace behaviac
{
	// Token: 0x020029A3 RID: 10659
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node16 : Condition
	{
		// Token: 0x06013C7A RID: 81018 RVA: 0x005EA82E File Offset: 0x005E8C2E
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node16()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013C7B RID: 81019 RVA: 0x005EA860 File Offset: 0x005E8C60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6E5 RID: 55013
		private int opl_p0;

		// Token: 0x0400D6E6 RID: 55014
		private int opl_p1;

		// Token: 0x0400D6E7 RID: 55015
		private int opl_p2;

		// Token: 0x0400D6E8 RID: 55016
		private int opl_p3;
	}
}
