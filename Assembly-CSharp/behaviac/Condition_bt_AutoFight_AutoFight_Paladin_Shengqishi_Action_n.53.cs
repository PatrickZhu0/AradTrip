using System;

namespace behaviac
{
	// Token: 0x02002858 RID: 10328
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node102 : Condition
	{
		// Token: 0x060139EE RID: 80366 RVA: 0x005DA239 File Offset: 0x005D8639
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node102()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060139EF RID: 80367 RVA: 0x005DA24C File Offset: 0x005D864C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D448 RID: 54344
		private float opl_p0;
	}
}
