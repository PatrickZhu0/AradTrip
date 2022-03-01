using System;

namespace behaviac
{
	// Token: 0x020021BA RID: 8634
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node32 : Condition
	{
		// Token: 0x06012D03 RID: 77059 RVA: 0x00588CBA File Offset: 0x005870BA
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node32()
		{
			this.opl_p0 = 0.63f;
		}

		// Token: 0x06012D04 RID: 77060 RVA: 0x00588CD0 File Offset: 0x005870D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6F6 RID: 50934
		private float opl_p0;
	}
}
