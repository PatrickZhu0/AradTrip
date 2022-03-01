using System;

namespace behaviac
{
	// Token: 0x020022A8 RID: 8872
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node26 : Action
	{
		// Token: 0x06012ECC RID: 77516 RVA: 0x005954F9 File Offset: 0x005938F9
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_hard_Action_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = BE_Equal.NotEqual;
			this.method_p2 = BE_State.DAODI;
		}

		// Token: 0x06012ECD RID: 77517 RVA: 0x0059551D File Offset: 0x0059391D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CheckState(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C8D6 RID: 51414
		private BE_Target method_p0;

		// Token: 0x0400C8D7 RID: 51415
		private BE_Equal method_p1;

		// Token: 0x0400C8D8 RID: 51416
		private BE_State method_p2;
	}
}
