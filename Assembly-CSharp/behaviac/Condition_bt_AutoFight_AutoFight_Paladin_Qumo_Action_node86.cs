using System;

namespace behaviac
{
	// Token: 0x020027F7 RID: 10231
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node86 : Condition
	{
		// Token: 0x0601392D RID: 80173 RVA: 0x005D5D3A File Offset: 0x005D413A
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node86()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601392E RID: 80174 RVA: 0x005D5D70 File Offset: 0x005D4170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D38B RID: 54155
		private int opl_p0;

		// Token: 0x0400D38C RID: 54156
		private int opl_p1;

		// Token: 0x0400D38D RID: 54157
		private int opl_p2;

		// Token: 0x0400D38E RID: 54158
		private int opl_p3;
	}
}
