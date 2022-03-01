using System;

namespace behaviac
{
	// Token: 0x02002E48 RID: 11848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node214 : Condition
	{
		// Token: 0x0601456D RID: 83309 RVA: 0x0061B09A File Offset: 0x0061949A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node214()
		{
			this.opl_p0 = 21637;
		}

		// Token: 0x0601456E RID: 83310 RVA: 0x0061B0B0 File Offset: 0x006194B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEFE RID: 57086
		private int opl_p0;
	}
}
