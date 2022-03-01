using System;

namespace behaviac
{
	// Token: 0x020034FC RID: 13564
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node31 : Action
	{
		// Token: 0x0601523B RID: 86587 RVA: 0x0065EBAE File Offset: 0x0065CFAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521793;
		}

		// Token: 0x0601523C RID: 86588 RVA: 0x0065EBCF File Offset: 0x0065CFCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB6C RID: 60268
		private BE_Target method_p0;

		// Token: 0x0400EB6D RID: 60269
		private int method_p1;
	}
}
