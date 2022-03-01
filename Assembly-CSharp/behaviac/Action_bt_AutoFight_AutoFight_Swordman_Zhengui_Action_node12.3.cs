using System;

namespace behaviac
{
	// Token: 0x0200299E RID: 10654
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node128 : Action
	{
		// Token: 0x06013C70 RID: 81008 RVA: 0x005EA642 File Offset: 0x005E8A42
		public Action_bt_AutoFight_AutoFight_Swordman_Zhengui_Action_node128()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 181101;
		}

		// Token: 0x06013C71 RID: 81009 RVA: 0x005EA663 File Offset: 0x005E8A63
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D6DB RID: 55003
		private BE_Target method_p0;

		// Token: 0x0400D6DC RID: 55004
		private int method_p1;
	}
}
