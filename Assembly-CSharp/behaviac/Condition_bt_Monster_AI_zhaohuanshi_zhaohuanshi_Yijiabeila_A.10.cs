using System;

namespace behaviac
{
	// Token: 0x0200400A RID: 16394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node27 : Condition
	{
		// Token: 0x06016778 RID: 92024 RVA: 0x006CC906 File Offset: 0x006CAD06
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yijiabeila_Action_node27()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06016779 RID: 92025 RVA: 0x006CC91C File Offset: 0x006CAD1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFC7 RID: 65479
		private float opl_p0;
	}
}
