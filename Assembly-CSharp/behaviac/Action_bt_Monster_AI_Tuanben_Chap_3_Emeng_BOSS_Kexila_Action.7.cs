using System;

namespace behaviac
{
	// Token: 0x0200384F RID: 14415
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node34 : Action
	{
		// Token: 0x06015884 RID: 88196 RVA: 0x0067F5DB File Offset: 0x0067D9DB
		public Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x06015885 RID: 88197 RVA: 0x0067F5FC File Offset: 0x0067D9FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F23D RID: 62013
		private int method_p0;

		// Token: 0x0400F23E RID: 62014
		private int method_p1;
	}
}
