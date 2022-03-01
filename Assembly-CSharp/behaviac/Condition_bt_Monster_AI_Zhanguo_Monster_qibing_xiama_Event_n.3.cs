using System;

namespace behaviac
{
	// Token: 0x02003EFB RID: 16123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node1 : Condition
	{
		// Token: 0x0601656D RID: 91501 RVA: 0x006C22BF File Offset: 0x006C06BF
		public Condition_bt_Monster_AI_Zhanguo_Monster_qibing_xiama_Event_node1()
		{
			this.opl_p0 = 7310;
		}

		// Token: 0x0601656E RID: 91502 RVA: 0x006C22D4 File Offset: 0x006C06D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD8C RID: 64908
		private int opl_p0;
	}
}
