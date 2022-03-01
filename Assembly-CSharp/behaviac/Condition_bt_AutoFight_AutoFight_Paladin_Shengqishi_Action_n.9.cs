using System;

namespace behaviac
{
	// Token: 0x0200281D RID: 10269
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node63 : Condition
	{
		// Token: 0x06013978 RID: 80248 RVA: 0x005D893B File Offset: 0x005D6D3B
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node63()
		{
			this.opl_p0 = 3724;
		}

		// Token: 0x06013979 RID: 80249 RVA: 0x005D8950 File Offset: 0x005D6D50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3D4 RID: 54228
		private int opl_p0;
	}
}
