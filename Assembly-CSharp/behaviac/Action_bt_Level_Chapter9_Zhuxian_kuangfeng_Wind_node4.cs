using System;

namespace behaviac
{
	// Token: 0x02002ADD RID: 10973
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4 : Action
	{
		// Token: 0x06013ED2 RID: 81618 RVA: 0x005FB169 File Offset: 0x005F9569
		public Action_bt_Level_Chapter9_Zhuxian_kuangfeng_Wind_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 550019;
			this.method_p1 = true;
		}

		// Token: 0x06013ED3 RID: 81619 RVA: 0x005FB18A File Offset: 0x005F958A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_AllPlayersAddBuffInfo(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D93E RID: 55614
		private int method_p0;

		// Token: 0x0400D93F RID: 55615
		private bool method_p1;
	}
}
