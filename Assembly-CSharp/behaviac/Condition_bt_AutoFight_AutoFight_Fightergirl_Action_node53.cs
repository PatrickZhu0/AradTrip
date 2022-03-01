using System;

namespace behaviac
{
	// Token: 0x02001EDA RID: 7898
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node53 : Condition
	{
		// Token: 0x06012759 RID: 75609 RVA: 0x00566555 File Offset: 0x00564955
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node53()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601275A RID: 75610 RVA: 0x00566568 File Offset: 0x00564968
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C14E RID: 49486
		private float opl_p0;
	}
}
