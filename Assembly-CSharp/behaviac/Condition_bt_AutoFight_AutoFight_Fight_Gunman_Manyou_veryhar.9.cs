using System;

namespace behaviac
{
	// Token: 0x020021B2 RID: 8626
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node22 : Condition
	{
		// Token: 0x06012CF3 RID: 77043 RVA: 0x005888D2 File Offset: 0x00586CD2
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node22()
		{
			this.opl_p0 = 0.67f;
		}

		// Token: 0x06012CF4 RID: 77044 RVA: 0x005888E8 File Offset: 0x00586CE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6E6 RID: 50918
		private float opl_p0;
	}
}
