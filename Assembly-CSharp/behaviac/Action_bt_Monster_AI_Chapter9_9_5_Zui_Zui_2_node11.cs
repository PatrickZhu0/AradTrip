using System;

namespace behaviac
{
	// Token: 0x020031EE RID: 12782
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node11 : Action
	{
		// Token: 0x06014C68 RID: 85096 RVA: 0x00642352 File Offset: 0x00640752
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570262;
		}

		// Token: 0x06014C69 RID: 85097 RVA: 0x00642373 File Offset: 0x00640773
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5C2 RID: 58818
		private BE_Target method_p0;

		// Token: 0x0400E5C3 RID: 58819
		private int method_p1;
	}
}
