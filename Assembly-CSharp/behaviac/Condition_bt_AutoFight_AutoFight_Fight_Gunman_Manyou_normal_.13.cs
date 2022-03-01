using System;

namespace behaviac
{
	// Token: 0x02002192 RID: 8594
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node32 : Condition
	{
		// Token: 0x06012CB4 RID: 76980 RVA: 0x00586E9E File Offset: 0x0058529E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node32()
		{
			this.opl_p0 = 0.57f;
		}

		// Token: 0x06012CB5 RID: 76981 RVA: 0x00586EB4 File Offset: 0x005852B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6A7 RID: 50855
		private float opl_p0;
	}
}
