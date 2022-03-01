using System;

namespace behaviac
{
	// Token: 0x0200365C RID: 13916
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node9 : Condition
	{
		// Token: 0x060154DA RID: 87258 RVA: 0x0066C807 File Offset: 0x0066AC07
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node9()
		{
			this.opl_p0 = 5425;
		}

		// Token: 0x060154DB RID: 87259 RVA: 0x0066C81C File Offset: 0x0066AC1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE92 RID: 61074
		private int opl_p0;
	}
}
