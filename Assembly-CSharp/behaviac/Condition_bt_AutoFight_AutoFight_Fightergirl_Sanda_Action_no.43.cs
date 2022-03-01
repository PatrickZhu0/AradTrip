using System;

namespace behaviac
{
	// Token: 0x02001F5C RID: 8028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node71 : Condition
	{
		// Token: 0x0601285B RID: 75867 RVA: 0x0056B7C2 File Offset: 0x00569BC2
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node71()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601285C RID: 75868 RVA: 0x0056B7D8 File Offset: 0x00569BD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C256 RID: 49750
		private float opl_p0;
	}
}
