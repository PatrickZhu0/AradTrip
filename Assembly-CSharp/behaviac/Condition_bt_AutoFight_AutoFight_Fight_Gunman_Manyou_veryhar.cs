using System;

namespace behaviac
{
	// Token: 0x020021A2 RID: 8610
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node2 : Condition
	{
		// Token: 0x06012CD3 RID: 77011 RVA: 0x005881B2 File Offset: 0x005865B2
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06012CD4 RID: 77012 RVA: 0x005881C8 File Offset: 0x005865C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6C6 RID: 50886
		private float opl_p0;
	}
}
