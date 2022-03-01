using System;

namespace behaviac
{
	// Token: 0x0200365B RID: 13915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node8 : Condition
	{
		// Token: 0x060154D8 RID: 87256 RVA: 0x0066C7C1 File Offset: 0x0066ABC1
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node8()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154D9 RID: 87257 RVA: 0x0066C7D4 File Offset: 0x0066ABD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE91 RID: 61073
		private float opl_p0;
	}
}
