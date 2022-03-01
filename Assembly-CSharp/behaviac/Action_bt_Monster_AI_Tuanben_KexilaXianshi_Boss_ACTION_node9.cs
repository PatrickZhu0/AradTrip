using System;

namespace behaviac
{
	// Token: 0x02003A4D RID: 14925
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node92 : Action
	{
		// Token: 0x06015C63 RID: 89187 RVA: 0x006939B2 File Offset: 0x00691DB2
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node92()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你们都是坏人！";
			this.method_p1 = 4f;
			this.method_p2 = 0;
		}

		// Token: 0x06015C64 RID: 89188 RVA: 0x006939DE File Offset: 0x00691DDE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F58B RID: 62859
		private string method_p0;

		// Token: 0x0400F58C RID: 62860
		private float method_p1;

		// Token: 0x0400F58D RID: 62861
		private int method_p2;
	}
}
