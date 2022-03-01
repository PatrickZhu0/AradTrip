using System;

namespace behaviac
{
	// Token: 0x0200403A RID: 16442
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node10 : Condition
	{
		// Token: 0x060167D3 RID: 92115 RVA: 0x006CEA26 File Offset: 0x006CCE26
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node10()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x060167D4 RID: 92116 RVA: 0x006CEA3C File Offset: 0x006CCE3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401001E RID: 65566
		private float opl_p0;
	}
}
