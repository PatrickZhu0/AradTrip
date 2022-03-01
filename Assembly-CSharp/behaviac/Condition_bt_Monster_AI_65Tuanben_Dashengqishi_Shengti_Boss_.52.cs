using System;

namespace behaviac
{
	// Token: 0x02002E26 RID: 11814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node184 : Condition
	{
		// Token: 0x06014529 RID: 83241 RVA: 0x0061A407 File Offset: 0x00618807
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node184()
		{
			this.opl_p0 = 21633;
		}

		// Token: 0x0601452A RID: 83242 RVA: 0x0061A41C File Offset: 0x0061881C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DECE RID: 57038
		private int opl_p0;
	}
}
