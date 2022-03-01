using System;

namespace behaviac
{
	// Token: 0x02002172 RID: 8562
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node42 : Condition
	{
		// Token: 0x06012C75 RID: 76917 RVA: 0x005854C6 File Offset: 0x005838C6
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node42()
		{
			this.opl_p0 = 0.69f;
		}

		// Token: 0x06012C76 RID: 76918 RVA: 0x005854DC File Offset: 0x005838DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C668 RID: 50792
		private float opl_p0;
	}
}
