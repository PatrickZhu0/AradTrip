using System;

namespace behaviac
{
	// Token: 0x02003B81 RID: 15233
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node11 : Action
	{
		// Token: 0x06015EB4 RID: 89780 RVA: 0x0069F99E File Offset: 0x0069DD9E
		public Action_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015EB5 RID: 89781 RVA: 0x0069F9BB File Offset: 0x0069DDBB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F777 RID: 63351
		private int method_p0;

		// Token: 0x0400F778 RID: 63352
		private int method_p1;
	}
}
