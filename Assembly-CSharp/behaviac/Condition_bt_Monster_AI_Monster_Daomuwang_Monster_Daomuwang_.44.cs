using System;

namespace behaviac
{
	// Token: 0x02003657 RID: 13911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node13 : Condition
	{
		// Token: 0x060154D0 RID: 87248 RVA: 0x0066C60D File Offset: 0x0066AA0D
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060154D1 RID: 87249 RVA: 0x0066C620 File Offset: 0x0066AA20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE89 RID: 61065
		private float opl_p0;
	}
}
