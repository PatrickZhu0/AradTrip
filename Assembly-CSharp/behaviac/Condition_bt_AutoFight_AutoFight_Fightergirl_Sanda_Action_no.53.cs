using System;

namespace behaviac
{
	// Token: 0x02001F69 RID: 8041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node62 : Condition
	{
		// Token: 0x06012875 RID: 75893 RVA: 0x0056BD46 File Offset: 0x0056A146
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node62()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06012876 RID: 75894 RVA: 0x0056BD5C File Offset: 0x0056A15C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C271 RID: 49777
		private float opl_p0;
	}
}
