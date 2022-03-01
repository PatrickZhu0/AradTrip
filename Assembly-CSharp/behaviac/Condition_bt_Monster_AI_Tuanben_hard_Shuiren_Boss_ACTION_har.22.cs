using System;

namespace behaviac
{
	// Token: 0x02003D5F RID: 15711
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node27 : Condition
	{
		// Token: 0x06016254 RID: 90708 RVA: 0x006B1253 File Offset: 0x006AF653
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node27()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06016255 RID: 90709 RVA: 0x006B1268 File Offset: 0x006AF668
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAAF RID: 64175
		private float opl_p0;
	}
}
