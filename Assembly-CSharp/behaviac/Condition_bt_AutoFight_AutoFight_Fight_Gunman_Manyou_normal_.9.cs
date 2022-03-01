using System;

namespace behaviac
{
	// Token: 0x0200218A RID: 8586
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node22 : Condition
	{
		// Token: 0x06012CA4 RID: 76964 RVA: 0x00586AB6 File Offset: 0x00584EB6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node22()
		{
			this.opl_p0 = 0.53f;
		}

		// Token: 0x06012CA5 RID: 76965 RVA: 0x00586ACC File Offset: 0x00584ECC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C697 RID: 50839
		private float opl_p0;
	}
}
