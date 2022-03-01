using System;

namespace behaviac
{
	// Token: 0x02002F0B RID: 12043
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4 : Condition
	{
		// Token: 0x060146ED RID: 83693 RVA: 0x00625773 File Offset: 0x00623B73
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node4()
		{
			this.opl_p0 = 21613;
		}

		// Token: 0x060146EE RID: 83694 RVA: 0x00625788 File Offset: 0x00623B88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E065 RID: 57445
		private int opl_p0;
	}
}
