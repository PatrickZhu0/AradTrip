using System;

namespace behaviac
{
	// Token: 0x02003653 RID: 13907
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node3 : Condition
	{
		// Token: 0x060154C8 RID: 87240 RVA: 0x0066C459 File Offset: 0x0066A859
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154C9 RID: 87241 RVA: 0x0066C46C File Offset: 0x0066A86C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE81 RID: 61057
		private float opl_p0;
	}
}
