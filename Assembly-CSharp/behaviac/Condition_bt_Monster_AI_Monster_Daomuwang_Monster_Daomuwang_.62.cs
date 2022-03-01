using System;

namespace behaviac
{
	// Token: 0x02003670 RID: 13936
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node13 : Condition
	{
		// Token: 0x06015501 RID: 87297 RVA: 0x0066D7D9 File Offset: 0x0066BBD9
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015502 RID: 87298 RVA: 0x0066D7EC File Offset: 0x0066BBEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEB9 RID: 61113
		private float opl_p0;
	}
}
