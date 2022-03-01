using System;

namespace behaviac
{
	// Token: 0x02003DCB RID: 15819
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node21 : Action
	{
		// Token: 0x06016325 RID: 90917 RVA: 0x006B5B02 File Offset: 0x006B3F02
		public Action_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 52172;
		}

		// Token: 0x06016326 RID: 90918 RVA: 0x006B5B23 File Offset: 0x006B3F23
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB86 RID: 64390
		private BE_Target method_p0;

		// Token: 0x0400FB87 RID: 64391
		private int method_p1;
	}
}
