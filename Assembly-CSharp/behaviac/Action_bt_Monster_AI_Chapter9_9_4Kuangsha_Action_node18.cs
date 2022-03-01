using System;

namespace behaviac
{
	// Token: 0x02003179 RID: 12665
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node18 : Action
	{
		// Token: 0x06014B89 RID: 84873 RVA: 0x0063D542 File Offset: 0x0063B942
		public Action_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570253;
		}

		// Token: 0x06014B8A RID: 84874 RVA: 0x0063D563 File Offset: 0x0063B963
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4F6 RID: 58614
		private BE_Target method_p0;

		// Token: 0x0400E4F7 RID: 58615
		private int method_p1;
	}
}
