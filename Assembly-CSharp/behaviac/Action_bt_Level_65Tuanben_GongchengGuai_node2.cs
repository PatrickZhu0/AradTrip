using System;

namespace behaviac
{
	// Token: 0x02002AD8 RID: 10968
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_65Tuanben_GongchengGuai_node2 : Action
	{
		// Token: 0x06013EC9 RID: 81609 RVA: 0x005FADE6 File Offset: 0x005F91E6
		public Action_bt_Level_65Tuanben_GongchengGuai_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "倒计时8分钟内没有通关将失败！";
			this.method_p1 = 8f;
		}

		// Token: 0x06013ECA RID: 81610 RVA: 0x005FAE0B File Offset: 0x005F920B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D93A RID: 55610
		private string method_p0;

		// Token: 0x0400D93B RID: 55611
		private float method_p1;
	}
}
