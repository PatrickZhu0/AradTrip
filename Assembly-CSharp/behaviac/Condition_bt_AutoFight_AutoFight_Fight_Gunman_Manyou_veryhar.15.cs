using System;

namespace behaviac
{
	// Token: 0x020021BE RID: 8638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node37 : Condition
	{
		// Token: 0x06012D0B RID: 77067 RVA: 0x00588E56 File Offset: 0x00587256
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node37()
		{
			this.opl_p0 = 0.72f;
		}

		// Token: 0x06012D0C RID: 77068 RVA: 0x00588E6C File Offset: 0x0058726C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6FE RID: 50942
		private float opl_p0;
	}
}
