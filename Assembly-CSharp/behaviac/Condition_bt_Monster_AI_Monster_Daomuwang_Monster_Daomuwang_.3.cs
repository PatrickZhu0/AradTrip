using System;

namespace behaviac
{
	// Token: 0x0200361E RID: 13854
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node29 : Condition
	{
		// Token: 0x06015460 RID: 87136 RVA: 0x00669F53 File Offset: 0x00668353
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node29()
		{
			this.opl_p0 = 5430;
		}

		// Token: 0x06015461 RID: 87137 RVA: 0x00669F68 File Offset: 0x00668368
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE1A RID: 60954
		private int opl_p0;
	}
}
