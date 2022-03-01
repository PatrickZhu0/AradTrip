using System;

namespace behaviac
{
	// Token: 0x02002E3F RID: 11839
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node202 : Condition
	{
		// Token: 0x0601455B RID: 83291 RVA: 0x0061AC6C File Offset: 0x0061906C
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node202()
		{
			this.opl_p0 = 21627;
		}

		// Token: 0x0601455C RID: 83292 RVA: 0x0061AC80 File Offset: 0x00619080
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEEF RID: 57071
		private int opl_p0;
	}
}
