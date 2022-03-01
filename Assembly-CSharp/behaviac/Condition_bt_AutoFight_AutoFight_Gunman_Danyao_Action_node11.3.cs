using System;

namespace behaviac
{
	// Token: 0x020025CE RID: 9678
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node112 : Condition
	{
		// Token: 0x060134E3 RID: 79075 RVA: 0x005BD3CB File Offset: 0x005BB7CB
		public Condition_bt_AutoFight_AutoFight_Gunman_Danyao_Action_node112()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 130802;
		}

		// Token: 0x060134E4 RID: 79076 RVA: 0x005BD3EC File Offset: 0x005BB7EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF24 RID: 53028
		private BE_Target opl_p0;

		// Token: 0x0400CF25 RID: 53029
		private BE_Equal opl_p1;

		// Token: 0x0400CF26 RID: 53030
		private int opl_p2;
	}
}
