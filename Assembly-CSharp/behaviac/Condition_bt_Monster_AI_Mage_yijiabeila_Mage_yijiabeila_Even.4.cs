using System;

namespace behaviac
{
	// Token: 0x020035B8 RID: 13752
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node5 : Condition
	{
		// Token: 0x0601539D RID: 86941 RVA: 0x00665D67 File Offset: 0x00664167
		public Condition_bt_Monster_AI_Mage_yijiabeila_Mage_yijiabeila_Event_yijiabeila_Shunyi_node5()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601539E RID: 86942 RVA: 0x00665D7C File Offset: 0x0066417C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED69 RID: 60777
		private float opl_p0;
	}
}
