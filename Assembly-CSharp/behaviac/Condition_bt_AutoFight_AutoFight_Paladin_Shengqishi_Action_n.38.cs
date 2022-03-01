using System;

namespace behaviac
{
	// Token: 0x02002844 RID: 10308
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node24 : Condition
	{
		// Token: 0x060139C6 RID: 80326 RVA: 0x005D99B5 File Offset: 0x005D7DB5
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node24()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x060139C7 RID: 80327 RVA: 0x005D99C8 File Offset: 0x005D7DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D420 RID: 54304
		private float opl_p0;
	}
}
