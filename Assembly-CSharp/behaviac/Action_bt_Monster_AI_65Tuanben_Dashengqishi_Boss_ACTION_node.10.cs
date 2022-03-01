using System;

namespace behaviac
{
	// Token: 0x02002DA4 RID: 11684
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node49 : Action
	{
		// Token: 0x06014429 RID: 82985 RVA: 0x00615F9E File Offset: 0x0061439E
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node49()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 4;
		}

		// Token: 0x0601442A RID: 82986 RVA: 0x00615FBB File Offset: 0x006143BB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDEF RID: 56815
		private int method_p0;

		// Token: 0x0400DDF0 RID: 56816
		private int method_p1;
	}
}
