using System;

namespace behaviac
{
	// Token: 0x02003646 RID: 13894
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node18 : Condition
	{
		// Token: 0x060154AF RID: 87215 RVA: 0x0066B7A9 File Offset: 0x00669BA9
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154B0 RID: 87216 RVA: 0x0066B7BC File Offset: 0x00669BBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE69 RID: 61033
		private float opl_p0;
	}
}
