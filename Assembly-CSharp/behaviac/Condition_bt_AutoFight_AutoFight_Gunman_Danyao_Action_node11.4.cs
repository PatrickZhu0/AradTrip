using System;

namespace behaviac
{
	// Token: 0x020025CF RID: 9679
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node113 : Condition
	{
		// Token: 0x060134E5 RID: 79077 RVA: 0x005BD42B File Offset: 0x005BB82B
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node113()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130803;
		}

		// Token: 0x060134E6 RID: 79078 RVA: 0x005BD44C File Offset: 0x005BB84C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF27 RID: 53031
		private BE_Target opl_p0;

		// Token: 0x0400CF28 RID: 53032
		private BE_Equal opl_p1;

		// Token: 0x0400CF29 RID: 53033
		private int opl_p2;
	}
}
