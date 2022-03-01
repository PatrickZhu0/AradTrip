using System;

namespace behaviac
{
	// Token: 0x02002BC7 RID: 11207
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node3 : Action
	{
		// Token: 0x06014090 RID: 82064 RVA: 0x006048CB File Offset: 0x00602CCB
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522225;
		}

		// Token: 0x06014091 RID: 82065 RVA: 0x006048EC File Offset: 0x00602CEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA7F RID: 55935
		private BE_Target method_p0;

		// Token: 0x0400DA80 RID: 55936
		private int method_p1;
	}
}
