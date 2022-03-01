using System;

namespace behaviac
{
	// Token: 0x02003FFE RID: 16382
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2 : Condition
	{
		// Token: 0x06016760 RID: 92000 RVA: 0x006CC3EA File Offset: 0x006CA7EA
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node2()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016761 RID: 92001 RVA: 0x006CC400 File Offset: 0x006CA800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFAF RID: 65455
		private float opl_p0;
	}
}
