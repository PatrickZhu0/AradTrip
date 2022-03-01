using System;

namespace behaviac
{
	// Token: 0x02002DD5 RID: 11733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node75 : Condition
	{
		// Token: 0x06014487 RID: 83079 RVA: 0x0061834B File Offset: 0x0061674B
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node75()
		{
			this.opl_p0 = 21631;
		}

		// Token: 0x06014488 RID: 83080 RVA: 0x00618360 File Offset: 0x00616760
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE42 RID: 56898
		private int opl_p0;
	}
}
