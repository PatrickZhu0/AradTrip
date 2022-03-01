using System;

namespace behaviac
{
	// Token: 0x02002A14 RID: 10772
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node20 : Condition
	{
		// Token: 0x06013D58 RID: 81240 RVA: 0x005F020F File Offset: 0x005EE60F
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node20()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x06013D59 RID: 81241 RVA: 0x005F0224 File Offset: 0x005EE624
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7C5 RID: 55237
		private int opl_p0;
	}
}
