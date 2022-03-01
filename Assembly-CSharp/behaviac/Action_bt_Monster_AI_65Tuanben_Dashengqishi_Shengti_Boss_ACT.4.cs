using System;

namespace behaviac
{
	// Token: 0x02002DD8 RID: 11736
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node91 : Action
	{
		// Token: 0x0601448D RID: 83085 RVA: 0x00618466 File Offset: 0x00616866
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node91()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x0601448E RID: 83086 RVA: 0x00618487 File Offset: 0x00616887
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE45 RID: 56901
		private BE_Target method_p0;

		// Token: 0x0400DE46 RID: 56902
		private int method_p1;
	}
}
