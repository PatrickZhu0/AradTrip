using System;

namespace behaviac
{
	// Token: 0x02003668 RID: 13928
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node28 : Condition
	{
		// Token: 0x060154F1 RID: 87281 RVA: 0x0066D471 File Offset: 0x0066B871
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154F2 RID: 87282 RVA: 0x0066D484 File Offset: 0x0066B884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEA9 RID: 61097
		private float opl_p0;
	}
}
