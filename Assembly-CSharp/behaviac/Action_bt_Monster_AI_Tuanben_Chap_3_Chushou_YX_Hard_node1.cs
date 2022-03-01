using System;

namespace behaviac
{
	// Token: 0x02003833 RID: 14387
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node1 : Action
	{
		// Token: 0x0601584F RID: 88143 RVA: 0x0067EA24 File Offset: 0x0067CE24
		public Action_bt_Monster_AI_Tuanben_Chap_3_Chushou_YX_Hard_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 180000;
			this.method_p1 = 0;
		}

		// Token: 0x06015850 RID: 88144 RVA: 0x0067EA48 File Offset: 0x0067CE48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F215 RID: 61973
		private int method_p0;

		// Token: 0x0400F216 RID: 61974
		private int method_p1;
	}
}
