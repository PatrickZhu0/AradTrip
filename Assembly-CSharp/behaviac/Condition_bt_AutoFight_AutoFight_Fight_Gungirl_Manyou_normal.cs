using System;

namespace behaviac
{
	// Token: 0x0200203A RID: 8250
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node2 : Condition
	{
		// Token: 0x06012A0E RID: 76302 RVA: 0x00576EEE File Offset: 0x005752EE
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node2()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012A0F RID: 76303 RVA: 0x00576F04 File Offset: 0x00575304
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C401 RID: 50177
		private float opl_p0;
	}
}
