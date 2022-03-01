using System;

namespace behaviac
{
	// Token: 0x02002DBF RID: 11711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node3 : Condition
	{
		// Token: 0x0601445D RID: 83037 RVA: 0x0061779A File Offset: 0x00615B9A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node3()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x0601445E RID: 83038 RVA: 0x006177AC File Offset: 0x00615BAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE20 RID: 56864
		private int opl_p0;
	}
}
