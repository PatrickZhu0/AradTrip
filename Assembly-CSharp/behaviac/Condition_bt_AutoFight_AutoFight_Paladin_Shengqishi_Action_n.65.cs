using System;

namespace behaviac
{
	// Token: 0x02002868 RID: 10344
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node43 : Condition
	{
		// Token: 0x06013A0E RID: 80398 RVA: 0x005DA965 File Offset: 0x005D8D65
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node43()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06013A0F RID: 80399 RVA: 0x005DA978 File Offset: 0x005D8D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D468 RID: 54376
		private float opl_p0;
	}
}
