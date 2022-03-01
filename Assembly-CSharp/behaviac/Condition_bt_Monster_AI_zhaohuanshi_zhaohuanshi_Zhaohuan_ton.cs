using System;

namespace behaviac
{
	// Token: 0x0200401B RID: 16411
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node4 : Condition
	{
		// Token: 0x06016798 RID: 92056 RVA: 0x006CD71E File Offset: 0x006CBB1E
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node4()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016799 RID: 92057 RVA: 0x006CD734 File Offset: 0x006CBB34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFE6 RID: 65510
		private float opl_p0;
	}
}
