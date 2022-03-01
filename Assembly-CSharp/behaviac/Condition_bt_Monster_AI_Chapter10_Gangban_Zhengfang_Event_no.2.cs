using System;

namespace behaviac
{
	// Token: 0x0200310A RID: 12554
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node5 : Condition
	{
		// Token: 0x06014ABF RID: 84671 RVA: 0x006399B7 File Offset: 0x00637DB7
		public Condition_bt_Monster_AI_Chapter10_Gangban_Zhengfang_Event_node5()
		{
			this.opl_p0 = 20721;
		}

		// Token: 0x06014AC0 RID: 84672 RVA: 0x006399CC File Offset: 0x00637DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E431 RID: 58417
		private int opl_p0;
	}
}
