using System;

namespace behaviac
{
	// Token: 0x0200354B RID: 13643
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node12 : Action
	{
		// Token: 0x060152D7 RID: 86743 RVA: 0x00661E8B File Offset: 0x0066028B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521739;
		}

		// Token: 0x060152D8 RID: 86744 RVA: 0x00661EAC File Offset: 0x006602AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC8E RID: 60558
		private BE_Target method_p0;

		// Token: 0x0400EC8F RID: 60559
		private int method_p1;
	}
}
