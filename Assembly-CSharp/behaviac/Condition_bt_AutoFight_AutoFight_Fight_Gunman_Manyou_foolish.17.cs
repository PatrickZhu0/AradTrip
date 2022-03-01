using System;

namespace behaviac
{
	// Token: 0x0200214A RID: 8522
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node42 : Condition
	{
		// Token: 0x06012C26 RID: 76838 RVA: 0x005836AA File Offset: 0x00581AAA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node42()
		{
			this.opl_p0 = 0.26f;
		}

		// Token: 0x06012C27 RID: 76839 RVA: 0x005836C0 File Offset: 0x00581AC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C619 RID: 50713
		private float opl_p0;
	}
}
