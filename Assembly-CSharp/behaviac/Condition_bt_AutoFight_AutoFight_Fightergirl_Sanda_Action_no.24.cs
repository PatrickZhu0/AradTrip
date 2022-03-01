using System;

namespace behaviac
{
	// Token: 0x02001F43 RID: 8003
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node42 : Condition
	{
		// Token: 0x06012829 RID: 75817 RVA: 0x0056ACBA File Offset: 0x005690BA
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node42()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x0601282A RID: 75818 RVA: 0x0056ACD0 File Offset: 0x005690D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C223 RID: 49699
		private float opl_p0;
	}
}
