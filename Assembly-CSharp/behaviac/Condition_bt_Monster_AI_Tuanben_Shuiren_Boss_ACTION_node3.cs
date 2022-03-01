using System;

namespace behaviac
{
	// Token: 0x02003B72 RID: 15218
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node3 : Condition
	{
		// Token: 0x06015E99 RID: 89753 RVA: 0x0069E3D3 File Offset: 0x0069C7D3
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node3()
		{
			this.opl_p0 = 21079;
		}

		// Token: 0x06015E9A RID: 89754 RVA: 0x0069E3E8 File Offset: 0x0069C7E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F75F RID: 63327
		private int opl_p0;
	}
}
