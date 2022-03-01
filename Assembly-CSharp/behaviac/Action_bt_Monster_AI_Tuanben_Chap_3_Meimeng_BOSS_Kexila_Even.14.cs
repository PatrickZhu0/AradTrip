using System;

namespace behaviac
{
	// Token: 0x02003961 RID: 14689
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node48 : Action
	{
		// Token: 0x06015A99 RID: 88729 RVA: 0x0068B11E File Offset: 0x0068951E
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A9A RID: 88730 RVA: 0x0068B155 File Offset: 0x00689555
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F439 RID: 62521
		private BE_Target method_p0;

		// Token: 0x0400F43A RID: 62522
		private int method_p1;

		// Token: 0x0400F43B RID: 62523
		private int method_p2;

		// Token: 0x0400F43C RID: 62524
		private int method_p3;

		// Token: 0x0400F43D RID: 62525
		private int method_p4;
	}
}
