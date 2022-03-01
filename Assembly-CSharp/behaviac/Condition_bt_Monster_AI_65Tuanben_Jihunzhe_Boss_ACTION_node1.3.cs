using System;

namespace behaviac
{
	// Token: 0x02002F10 RID: 12048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12 : Condition
	{
		// Token: 0x060146F7 RID: 83703 RVA: 0x006259BA File Offset: 0x00623DBA
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_ACTION_node12()
		{
			this.opl_p0 = 21616;
		}

		// Token: 0x060146F8 RID: 83704 RVA: 0x006259D0 File Offset: 0x00623DD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E06E RID: 57454
		private int opl_p0;
	}
}
