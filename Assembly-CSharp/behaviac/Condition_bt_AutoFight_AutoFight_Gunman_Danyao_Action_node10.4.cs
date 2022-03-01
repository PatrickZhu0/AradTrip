using System;

namespace behaviac
{
	// Token: 0x020025B6 RID: 9654
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node103 : Condition
	{
		// Token: 0x060134B3 RID: 79027 RVA: 0x005BC9FB File Offset: 0x005BADFB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node103()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130802;
		}

		// Token: 0x060134B4 RID: 79028 RVA: 0x005BCA1C File Offset: 0x005BAE1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CEEC RID: 52972
		private BE_Target opl_p0;

		// Token: 0x0400CEED RID: 52973
		private BE_Equal opl_p1;

		// Token: 0x0400CEEE RID: 52974
		private int opl_p2;
	}
}
