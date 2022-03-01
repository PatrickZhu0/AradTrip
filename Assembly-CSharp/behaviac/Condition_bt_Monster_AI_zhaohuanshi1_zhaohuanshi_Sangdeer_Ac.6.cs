using System;

namespace behaviac
{
	// Token: 0x02004099 RID: 16537
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node11 : Condition
	{
		// Token: 0x0601688D RID: 92301 RVA: 0x006D2AD9 File Offset: 0x006D0ED9
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Sangdeer_Action_node11()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x0601688E RID: 92302 RVA: 0x006D2AEC File Offset: 0x006D0EEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100D7 RID: 65751
		private int opl_p0;
	}
}
