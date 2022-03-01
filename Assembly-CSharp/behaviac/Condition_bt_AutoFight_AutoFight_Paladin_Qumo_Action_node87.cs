using System;

namespace behaviac
{
	// Token: 0x020027F8 RID: 10232
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node87 : Condition
	{
		// Token: 0x0601392F RID: 80175 RVA: 0x005D5DB5 File Offset: 0x005D41B5
		public Condition_bt_AutoFight_AutoFight_Paladin_Qumo_Action_node87()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013930 RID: 80176 RVA: 0x005D5DC8 File Offset: 0x005D41C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D38F RID: 54159
		private float opl_p0;
	}
}
