using System;

namespace behaviac
{
	// Token: 0x02001F35 RID: 7989
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node53 : Condition
	{
		// Token: 0x0601280D RID: 75789 RVA: 0x0056A6B2 File Offset: 0x00568AB2
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node53()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601280E RID: 75790 RVA: 0x0056A6C8 File Offset: 0x00568AC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C203 RID: 49667
		private float opl_p0;
	}
}
