using System;

namespace behaviac
{
	// Token: 0x02003FEE RID: 16366
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node9 : Condition
	{
		// Token: 0x06016742 RID: 91970 RVA: 0x006CB83A File Offset: 0x006C9C3A
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node9()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06016743 RID: 91971 RVA: 0x006CB850 File Offset: 0x006C9C50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF93 RID: 65427
		private float opl_p0;
	}
}
