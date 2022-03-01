using System;

namespace behaviac
{
	// Token: 0x02001F47 RID: 8007
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node64 : Condition
	{
		// Token: 0x06012831 RID: 75825 RVA: 0x0056AE72 File Offset: 0x00569272
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node64()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06012832 RID: 75826 RVA: 0x0056AE88 File Offset: 0x00569288
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C22B RID: 49707
		private float opl_p0;
	}
}
