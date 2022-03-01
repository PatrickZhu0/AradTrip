using System;

namespace behaviac
{
	// Token: 0x02004062 RID: 16482
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node60 : Condition
	{
		// Token: 0x06016823 RID: 92195 RVA: 0x006CFB2E File Offset: 0x006CDF2E
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node60()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06016824 RID: 92196 RVA: 0x006CFB44 File Offset: 0x006CDF44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401006E RID: 65646
		private float opl_p0;
	}
}
