using System;

namespace behaviac
{
	// Token: 0x0200216A RID: 8554
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node32 : Condition
	{
		// Token: 0x06012C65 RID: 76901 RVA: 0x00585082 File Offset: 0x00583482
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node32()
		{
			this.opl_p0 = 0.63f;
		}

		// Token: 0x06012C66 RID: 76902 RVA: 0x00585098 File Offset: 0x00583498
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C658 RID: 50776
		private float opl_p0;
	}
}
