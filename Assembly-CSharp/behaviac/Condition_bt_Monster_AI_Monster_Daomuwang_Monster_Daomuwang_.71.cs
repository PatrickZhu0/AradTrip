using System;

namespace behaviac
{
	// Token: 0x0200367C RID: 13948
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node23 : Condition
	{
		// Token: 0x06015519 RID: 87321 RVA: 0x0066DCF5 File Offset: 0x0066C0F5
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601551A RID: 87322 RVA: 0x0066DD08 File Offset: 0x0066C108
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EED1 RID: 61137
		private float opl_p0;
	}
}
