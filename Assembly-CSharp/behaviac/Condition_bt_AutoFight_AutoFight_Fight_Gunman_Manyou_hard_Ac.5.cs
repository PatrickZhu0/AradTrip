using System;

namespace behaviac
{
	// Token: 0x0200215A RID: 8538
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node12 : Condition
	{
		// Token: 0x06012C45 RID: 76869 RVA: 0x005848B2 File Offset: 0x00582CB2
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node12()
		{
			this.opl_p0 = 0.73f;
		}

		// Token: 0x06012C46 RID: 76870 RVA: 0x005848C8 File Offset: 0x00582CC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C638 RID: 50744
		private float opl_p0;
	}
}
