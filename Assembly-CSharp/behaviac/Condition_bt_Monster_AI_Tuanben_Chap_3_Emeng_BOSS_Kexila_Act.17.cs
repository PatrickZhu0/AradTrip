using System;

namespace behaviac
{
	// Token: 0x02003851 RID: 14417
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node51 : Condition
	{
		// Token: 0x06015888 RID: 88200 RVA: 0x0067F683 File Offset: 0x0067DA83
		public Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Action_node51()
		{
			this.opl_p0 = 21216;
		}

		// Token: 0x06015889 RID: 88201 RVA: 0x0067F698 File Offset: 0x0067DA98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F242 RID: 62018
		private int opl_p0;
	}
}
