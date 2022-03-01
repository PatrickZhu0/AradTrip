using System;

namespace behaviac
{
	// Token: 0x0200270A RID: 9994
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node82 : Condition
	{
		// Token: 0x06013756 RID: 79702 RVA: 0x005CC38F File Offset: 0x005CA78F
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node82()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 230302;
		}

		// Token: 0x06013757 RID: 79703 RVA: 0x005CC3B0 File Offset: 0x005CA7B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1AF RID: 53679
		private BE_Target opl_p0;

		// Token: 0x0400D1B0 RID: 53680
		private BE_Equal opl_p1;

		// Token: 0x0400D1B1 RID: 53681
		private int opl_p2;
	}
}
