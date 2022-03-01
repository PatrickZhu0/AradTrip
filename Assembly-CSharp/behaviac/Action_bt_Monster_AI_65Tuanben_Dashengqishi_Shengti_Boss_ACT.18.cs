using System;

namespace behaviac
{
	// Token: 0x02002E03 RID: 11779
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node99 : Action
	{
		// Token: 0x060144E3 RID: 83171 RVA: 0x006195C6 File Offset: 0x006179C6
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node99()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x060144E4 RID: 83172 RVA: 0x006195E7 File Offset: 0x006179E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE8E RID: 56974
		private BE_Target method_p0;

		// Token: 0x0400DE8F RID: 56975
		private int method_p1;
	}
}
