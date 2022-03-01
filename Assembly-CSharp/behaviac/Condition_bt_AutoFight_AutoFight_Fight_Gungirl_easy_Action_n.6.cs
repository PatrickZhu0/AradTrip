using System;

namespace behaviac
{
	// Token: 0x02001F7D RID: 8061
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node4 : Condition
	{
		// Token: 0x0601289A RID: 75930 RVA: 0x0056DC59 File Offset: 0x0056C059
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node4()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x0601289B RID: 75931 RVA: 0x0056DC6C File Offset: 0x0056C06C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C28D RID: 49805
		private int opl_p0;
	}
}
