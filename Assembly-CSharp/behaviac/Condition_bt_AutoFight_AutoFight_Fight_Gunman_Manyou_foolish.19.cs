using System;

namespace behaviac
{
	// Token: 0x0200214E RID: 8526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node47 : Condition
	{
		// Token: 0x06012C2E RID: 76846 RVA: 0x00583846 File Offset: 0x00581C46
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node47()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06012C2F RID: 76847 RVA: 0x0058385C File Offset: 0x00581C5C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C621 RID: 50721
		private float opl_p0;
	}
}
