using System;

namespace behaviac
{
	// Token: 0x020029BF RID: 10687
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node9 : Condition
	{
		// Token: 0x06013CB2 RID: 81074 RVA: 0x005EB3E5 File Offset: 0x005E97E5
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node9()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013CB3 RID: 81075 RVA: 0x005EB404 File Offset: 0x005E9804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D720 RID: 55072
		private BE_Target opl_p0;

		// Token: 0x0400D721 RID: 55073
		private BE_Equal opl_p1;

		// Token: 0x0400D722 RID: 55074
		private BE_State opl_p2;
	}
}
