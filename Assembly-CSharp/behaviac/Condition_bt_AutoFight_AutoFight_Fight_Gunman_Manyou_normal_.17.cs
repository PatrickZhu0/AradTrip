using System;

namespace behaviac
{
	// Token: 0x0200219A RID: 8602
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node42 : Condition
	{
		// Token: 0x06012CC4 RID: 76996 RVA: 0x005872E2 File Offset: 0x005856E2
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node42()
		{
			this.opl_p0 = 0.54f;
		}

		// Token: 0x06012CC5 RID: 76997 RVA: 0x005872F8 File Offset: 0x005856F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6B7 RID: 50871
		private float opl_p0;
	}
}
