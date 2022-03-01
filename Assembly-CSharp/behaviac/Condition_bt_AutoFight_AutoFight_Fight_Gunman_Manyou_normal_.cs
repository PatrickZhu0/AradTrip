using System;

namespace behaviac
{
	// Token: 0x0200217A RID: 8570
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node2 : Condition
	{
		// Token: 0x06012C84 RID: 76932 RVA: 0x00586396 File Offset: 0x00584796
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node2()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06012C85 RID: 76933 RVA: 0x005863AC File Offset: 0x005847AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C677 RID: 50807
		private float opl_p0;
	}
}
