using System;

namespace behaviac
{
	// Token: 0x02003622 RID: 13858
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node4 : Condition
	{
		// Token: 0x06015468 RID: 87144 RVA: 0x0066A107 File Offset: 0x00668507
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_node4()
		{
			this.opl_p0 = 5428;
		}

		// Token: 0x06015469 RID: 87145 RVA: 0x0066A11C File Offset: 0x0066851C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE22 RID: 60962
		private int opl_p0;
	}
}
