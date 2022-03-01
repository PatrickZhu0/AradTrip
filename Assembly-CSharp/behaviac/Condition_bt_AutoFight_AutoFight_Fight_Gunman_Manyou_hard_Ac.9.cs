using System;

namespace behaviac
{
	// Token: 0x02002162 RID: 8546
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node22 : Condition
	{
		// Token: 0x06012C55 RID: 76885 RVA: 0x00584C9A File Offset: 0x0058309A
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node22()
		{
			this.opl_p0 = 0.67f;
		}

		// Token: 0x06012C56 RID: 76886 RVA: 0x00584CB0 File Offset: 0x005830B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C648 RID: 50760
		private float opl_p0;
	}
}
