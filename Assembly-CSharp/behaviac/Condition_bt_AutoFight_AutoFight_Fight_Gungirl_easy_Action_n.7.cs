using System;

namespace behaviac
{
	// Token: 0x02001F7F RID: 8063
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node12 : Condition
	{
		// Token: 0x0601289E RID: 75934 RVA: 0x0056DD4A File Offset: 0x0056C14A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node12()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601289F RID: 75935 RVA: 0x0056DD60 File Offset: 0x0056C160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C290 RID: 49808
		private float opl_p0;
	}
}
