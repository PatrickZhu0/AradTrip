using System;

namespace behaviac
{
	// Token: 0x0200200E RID: 8206
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node47 : Condition
	{
		// Token: 0x060129B8 RID: 76216 RVA: 0x005742B2 File Offset: 0x005726B2
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node47()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060129B9 RID: 76217 RVA: 0x005742C8 File Offset: 0x005726C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3AB RID: 50091
		private float opl_p0;
	}
}
