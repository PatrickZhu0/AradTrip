using System;

namespace behaviac
{
	// Token: 0x0200363E RID: 13886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node13 : Condition
	{
		// Token: 0x0601549F RID: 87199 RVA: 0x0066B441 File Offset: 0x00669841
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060154A0 RID: 87200 RVA: 0x0066B454 File Offset: 0x00669854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE59 RID: 61017
		private float opl_p0;
	}
}
