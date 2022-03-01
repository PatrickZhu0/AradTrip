using System;

namespace behaviac
{
	// Token: 0x02002E09 RID: 11785
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node106 : Action
	{
		// Token: 0x060144EF RID: 83183 RVA: 0x006197B6 File Offset: 0x00617BB6
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node106()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x060144F0 RID: 83184 RVA: 0x006197D7 File Offset: 0x00617BD7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE96 RID: 56982
		private BE_Target method_p0;

		// Token: 0x0400DE97 RID: 56983
		private int method_p1;
	}
}
