using System;

namespace behaviac
{
	// Token: 0x02001F8B RID: 8075
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node27 : Condition
	{
		// Token: 0x060128B6 RID: 75958 RVA: 0x0056E3C6 File Offset: 0x0056C7C6
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node27()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060128B7 RID: 75959 RVA: 0x0056E3DC File Offset: 0x0056C7DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A8 RID: 49832
		private float opl_p0;
	}
}
