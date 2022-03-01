using System;

namespace behaviac
{
	// Token: 0x02003625 RID: 13861
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node13 : Condition
	{
		// Token: 0x0601546E RID: 87150 RVA: 0x0066A275 File Offset: 0x00668675
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x0601546F RID: 87151 RVA: 0x0066A288 File Offset: 0x00668688
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE29 RID: 60969
		private float opl_p0;
	}
}
