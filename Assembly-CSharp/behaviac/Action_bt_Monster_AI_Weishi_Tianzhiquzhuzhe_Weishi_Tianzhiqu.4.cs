using System;

namespace behaviac
{
	// Token: 0x02003E03 RID: 15875
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node11 : Action
	{
		// Token: 0x06016390 RID: 91024 RVA: 0x006B7CA3 File Offset: 0x006B60A3
		public Action_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528401;
		}

		// Token: 0x06016391 RID: 91025 RVA: 0x006B7CC4 File Offset: 0x006B60C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBF7 RID: 64503
		private BE_Target method_p0;

		// Token: 0x0400FBF8 RID: 64504
		private int method_p1;
	}
}
