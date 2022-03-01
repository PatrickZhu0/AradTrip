using System;

namespace behaviac
{
	// Token: 0x02004036 RID: 16438
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node5 : Condition
	{
		// Token: 0x060167CB RID: 92107 RVA: 0x006CE872 File Offset: 0x006CCC72
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node5()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060167CC RID: 92108 RVA: 0x006CE888 File Offset: 0x006CCC88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010016 RID: 65558
		private float opl_p0;
	}
}
