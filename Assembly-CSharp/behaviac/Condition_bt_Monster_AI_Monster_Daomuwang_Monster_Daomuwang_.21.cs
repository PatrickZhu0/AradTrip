using System;

namespace behaviac
{
	// Token: 0x02003637 RID: 13879
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node29 : Condition
	{
		// Token: 0x06015491 RID: 87185 RVA: 0x0066B11F File Offset: 0x0066951F
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node29()
		{
			this.opl_p0 = 5430;
		}

		// Token: 0x06015492 RID: 87186 RVA: 0x0066B134 File Offset: 0x00669534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE4A RID: 61002
		private int opl_p0;
	}
}
