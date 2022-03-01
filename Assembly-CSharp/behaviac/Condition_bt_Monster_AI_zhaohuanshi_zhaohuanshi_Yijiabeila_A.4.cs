using System;

namespace behaviac
{
	// Token: 0x02004002 RID: 16386
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node22 : Condition
	{
		// Token: 0x06016768 RID: 92008 RVA: 0x006CC59E File Offset: 0x006CA99E
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node22()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016769 RID: 92009 RVA: 0x006CC5B4 File Offset: 0x006CA9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFB7 RID: 65463
		private float opl_p0;
	}
}
