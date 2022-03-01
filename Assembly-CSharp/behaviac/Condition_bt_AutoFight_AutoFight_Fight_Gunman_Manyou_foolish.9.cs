using System;

namespace behaviac
{
	// Token: 0x0200213A RID: 8506
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node22 : Condition
	{
		// Token: 0x06012C06 RID: 76806 RVA: 0x00582E7E File Offset: 0x0058127E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node22()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012C07 RID: 76807 RVA: 0x00582E94 File Offset: 0x00581294
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5F9 RID: 50681
		private float opl_p0;
	}
}
