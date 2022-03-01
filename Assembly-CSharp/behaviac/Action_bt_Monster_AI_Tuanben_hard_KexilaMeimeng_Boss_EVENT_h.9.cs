using System;

namespace behaviac
{
	// Token: 0x02003C60 RID: 15456
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node41 : Action
	{
		// Token: 0x06016068 RID: 90216 RVA: 0x006A8057 File Offset: 0x006A6457
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x06016069 RID: 90217 RVA: 0x006A8078 File Offset: 0x006A6478
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8E9 RID: 63721
		private BE_Target method_p0;

		// Token: 0x0400F8EA RID: 63722
		private int method_p1;
	}
}
