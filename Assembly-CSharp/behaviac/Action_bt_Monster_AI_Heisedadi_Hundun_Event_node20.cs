using System;

namespace behaviac
{
	// Token: 0x0200345F RID: 13407
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node20 : Action
	{
		// Token: 0x0601510A RID: 86282 RVA: 0x00658906 File Offset: 0x00656D06
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node20()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521858;
		}

		// Token: 0x0601510B RID: 86283 RVA: 0x00658927 File Offset: 0x00656D27
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA02 RID: 59906
		private BE_Target method_p0;

		// Token: 0x0400EA03 RID: 59907
		private int method_p1;
	}
}
