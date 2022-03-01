using System;

namespace behaviac
{
	// Token: 0x02003C66 RID: 15462
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node46 : Action
	{
		// Token: 0x06016074 RID: 90228 RVA: 0x006A8202 File Offset: 0x006A6602
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
		}

		// Token: 0x06016075 RID: 90229 RVA: 0x006A8223 File Offset: 0x006A6623
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8F6 RID: 63734
		private BE_Target method_p0;

		// Token: 0x0400F8F7 RID: 63735
		private int method_p1;
	}
}
