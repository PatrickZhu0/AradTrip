using System;

namespace behaviac
{
	// Token: 0x0200297E RID: 10622
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node6 : Condition
	{
		// Token: 0x06013C30 RID: 80944 RVA: 0x005E96D2 File Offset: 0x005E7AD2
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 180014;
		}

		// Token: 0x06013C31 RID: 80945 RVA: 0x005E96F4 File Offset: 0x005E7AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D698 RID: 54936
		private BE_Target opl_p0;

		// Token: 0x0400D699 RID: 54937
		private BE_Equal opl_p1;

		// Token: 0x0400D69A RID: 54938
		private int opl_p2;
	}
}
