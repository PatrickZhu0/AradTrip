using System;

namespace behaviac
{
	// Token: 0x02003BCF RID: 15311
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node53 : Action
	{
		// Token: 0x06015F4B RID: 89931 RVA: 0x006A2961 File Offset: 0x006A0D61
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
		}

		// Token: 0x06015F4C RID: 89932 RVA: 0x006A2982 File Offset: 0x006A0D82
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7E4 RID: 63460
		private BE_Target method_p0;

		// Token: 0x0400F7E5 RID: 63461
		private int method_p1;
	}
}
