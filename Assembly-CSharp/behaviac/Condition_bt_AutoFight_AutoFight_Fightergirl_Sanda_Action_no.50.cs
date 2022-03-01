using System;

namespace behaviac
{
	// Token: 0x02001F65 RID: 8037
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node82 : Condition
	{
		// Token: 0x0601286D RID: 75885 RVA: 0x0056BB8E File Offset: 0x00569F8E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node82()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601286E RID: 75886 RVA: 0x0056BBA4 File Offset: 0x00569FA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C269 RID: 49769
		private float opl_p0;
	}
}
