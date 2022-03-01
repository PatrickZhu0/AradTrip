using System;

namespace behaviac
{
	// Token: 0x020040A7 RID: 16551
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node2 : Condition
	{
		// Token: 0x060168A7 RID: 92327 RVA: 0x006D35C6 File Offset: 0x006D19C6
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Yijiabeila_Action_node2()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060168A8 RID: 92328 RVA: 0x006D35DC File Offset: 0x006D19DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100EE RID: 65774
		private float opl_p0;
	}
}
