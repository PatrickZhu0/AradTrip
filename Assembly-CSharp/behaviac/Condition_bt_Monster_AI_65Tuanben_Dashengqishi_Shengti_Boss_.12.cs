using System;

namespace behaviac
{
	// Token: 0x02002DDF RID: 11743
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node27 : Condition
	{
		// Token: 0x0601449B RID: 83099 RVA: 0x0061874E File Offset: 0x00616B4E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node27()
		{
			this.opl_p0 = 21653;
		}

		// Token: 0x0601449C RID: 83100 RVA: 0x00618764 File Offset: 0x00616B64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE53 RID: 56915
		private int opl_p0;
	}
}
