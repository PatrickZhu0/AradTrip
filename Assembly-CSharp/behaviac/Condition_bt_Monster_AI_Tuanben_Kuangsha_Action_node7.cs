using System;

namespace behaviac
{
	// Token: 0x02003ABE RID: 15038
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node7 : Condition
	{
		// Token: 0x06015D3B RID: 89403 RVA: 0x00698544 File Offset: 0x00696944
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node7()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015D3C RID: 89404 RVA: 0x00698554 File Offset: 0x00696954
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F653 RID: 63059
		private int opl_p0;
	}
}
