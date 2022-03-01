using System;

namespace behaviac
{
	// Token: 0x020027F3 RID: 10227
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node81 : Condition
	{
		// Token: 0x06013925 RID: 80165 RVA: 0x005D5B86 File Offset: 0x005D3F86
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node81()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013926 RID: 80166 RVA: 0x005D5BBC File Offset: 0x005D3FBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D383 RID: 54147
		private int opl_p0;

		// Token: 0x0400D384 RID: 54148
		private int opl_p1;

		// Token: 0x0400D385 RID: 54149
		private int opl_p2;

		// Token: 0x0400D386 RID: 54150
		private int opl_p3;
	}
}
