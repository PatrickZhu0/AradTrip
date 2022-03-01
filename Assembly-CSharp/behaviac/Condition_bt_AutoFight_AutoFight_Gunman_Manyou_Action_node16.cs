using System;

namespace behaviac
{
	// Token: 0x020025FF RID: 9727
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node16 : Condition
	{
		// Token: 0x06013544 RID: 79172 RVA: 0x005C047A File Offset: 0x005BE87A
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node16()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013545 RID: 79173 RVA: 0x005C0490 File Offset: 0x005BE890
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CF90 RID: 53136
		private float opl_p0;
	}
}
