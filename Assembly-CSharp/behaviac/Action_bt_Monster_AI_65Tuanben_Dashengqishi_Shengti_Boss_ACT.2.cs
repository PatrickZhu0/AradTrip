using System;

namespace behaviac
{
	// Token: 0x02002DD2 RID: 11730
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node90 : Action
	{
		// Token: 0x06014481 RID: 83073 RVA: 0x00618276 File Offset: 0x00616676
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node90()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x06014482 RID: 83074 RVA: 0x00618297 File Offset: 0x00616697
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE3D RID: 56893
		private BE_Target method_p0;

		// Token: 0x0400DE3E RID: 56894
		private int method_p1;
	}
}
