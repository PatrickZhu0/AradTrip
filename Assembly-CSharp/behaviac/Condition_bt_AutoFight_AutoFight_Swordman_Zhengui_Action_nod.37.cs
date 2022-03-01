using System;

namespace behaviac
{
	// Token: 0x020029AD RID: 10669
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node110 : Condition
	{
		// Token: 0x06013C8E RID: 81038 RVA: 0x005EAC55 File Offset: 0x005E9055
		public Condition_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node110()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013C8F RID: 81039 RVA: 0x005EAC74 File Offset: 0x005E9074
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6FA RID: 55034
		private BE_Target opl_p0;

		// Token: 0x0400D6FB RID: 55035
		private BE_Equal opl_p1;

		// Token: 0x0400D6FC RID: 55036
		private BE_State opl_p2;
	}
}
