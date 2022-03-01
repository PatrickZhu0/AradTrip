using System;

namespace behaviac
{
	// Token: 0x02003713 RID: 14099
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node14 : Action
	{
		// Token: 0x06015634 RID: 87604 RVA: 0x00673CEF File Offset: 0x006720EF
		public Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06015635 RID: 87605 RVA: 0x00673D10 File Offset: 0x00672110
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFFE RID: 61438
		private BE_Target method_p0;

		// Token: 0x0400EFFF RID: 61439
		private int method_p1;
	}
}
